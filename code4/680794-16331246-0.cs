    [WebService(Namespace = "http://YourNameSpaceGoesHere/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class IncDedWebService : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public string GetInceDed(int id)
        {
            ClsSalary salary = new ClsSalary();
            //var abc  salary=.GetIncDedByEmpId(id);
            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(new ClsSalary
                                                {
                                                  Amount   = 1234,
                                                  Id = 123,
                                                  Name = "Basic Salary"
                                                });
            return json;
        }
    }
    public class ClsSalary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
