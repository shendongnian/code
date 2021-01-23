    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Services;
    
    namespace EmployeeRecs
    {
        /// <summary>
        /// Summary description for Service1
        /// </summary>
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
        // [System.Web.Script.Services.ScriptService]
        public class Service1 : System.Web.Services.WebService
        {
    
                   //Create new web method to get Employee last name
            [WebMethod]
            public List<Employee> GetEmployee(string firstName)
            {
                return DataHelper.GetEmployee(firstName);
    
            }
        }
    }
