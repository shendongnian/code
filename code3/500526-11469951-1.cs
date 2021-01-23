    [WebService(Namespace = "WebService")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        [System.Web.Script.Services.ScriptService]
        public class YourNameIs : System.Web.Services.WebService
        {
            [WebMethod, ScriptMethod]
            public string GetName(string Name)
            {
                return MyClass.GetName(Name);
            }
    
        }
