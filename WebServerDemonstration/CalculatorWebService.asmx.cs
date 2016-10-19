using System.Collections.Generic;
using System.Web.Services;

namespace WebServerDemonstration
{
    /// <summary>
    /// Summary description for CalculatorWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CalculatorWebService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession =true)]
        public int Add(int firstNumber, int secondNumber)
        {
            List<string> calculations;

            if (Session["CALCULATIONS"] == null)
            {
                calculations = new List<string>();
            }
            else
            {
                calculations = (List<string>)Session["CALCULATIONS"];
            }

            string strRecentCalculation = firstNumber.ToString() + "+" + secondNumber.ToString() + " = " + (firstNumber + secondNumber).ToString();

            calculations.Add(strRecentCalculation);
            Session["CALCULATIONS"] = calculations;

            return firstNumber + secondNumber;
        }
    }
}
