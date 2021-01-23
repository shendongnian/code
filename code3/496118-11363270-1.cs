    [WebInvoke(Method = "GET", UriTemplate = "/Update?formData={formData}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public bool Update(string formData)
        {
            var mlParser = new MLParser();
            System.Web.Script.Serialization.JavaScriptSerializer s = new System.Web.Script.Serialization.JavaScriptSerializer();
                var InfoList = s.Deserialize<Users>(formData);
            return mlParser.Update(InfoList);
        }
 
    public class Users
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
