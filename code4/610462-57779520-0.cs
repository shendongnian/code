    namespace MyWebServices
    {
        [ServiceContract]
        [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
        [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
        public class ExampleWebService
        {
            [OperationContract]
            [WebInvoke(Method = "POST",
                BodyStyle = WebMessageBodyStyle.Bare,
                ResponseFormat = WebMessageFormat.Json,
                RequestFormat = WebMessageFormat.Json)]
            public string DoWork(DoWorkRequest request)
            {
                return "success!";
            }
        }
    }
  
