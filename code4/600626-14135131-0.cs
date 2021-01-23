    [AspNetCompatibilityRequirements( RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed )]
    public class MyService {
        [OperationContract]
        public string Foo() {
        
            var request = System.Web.HttpContext.Current.Request;   
        }
    }
