    namespace UI.Web.WebServices
    {
        [ServiceContract(Namespace = "WebServices")]
        [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
        public class WebServiceName
        {
            [OperationContract]
            [WebInvoke(ResponseFormat = WebMessageFormat.Json)]
            public FacilityResult[] MethodName()
            {
                FacilityService facilityService = new 
                return facilityService .GetAssignments()).ToArray();
            }
        }
    }
