    public partial class MyPage : System.Web.UI.Page
    {
        ...
    
        public class JSONItem
        {
            public string Id { get; set; }
            public string Title { get; set; }  
            public RegistrationPage RegistrationPage { get; set; }           
        }
    
        public class RegistrationPage
        {
             public string Registration { get; set; }
        }
    
        [WebMethod]
        public static Policy Save(Policy policy)
        {
        }
    
        ...
    }
