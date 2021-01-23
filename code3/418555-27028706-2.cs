**Service Contract: IService.cs**
    namespace DontTazeMe.Bro
    {
        [ServiceContract]
        public interface IService
        {
            [OperationContract]
            [WebGet]
            List<GeoMapData> GetToTheChopper();
        }
    }
**Implementation: Service.cs**
    namespace DontTazeMe.Bro
    {
        public class WSDLService : IService
        {
            public List<GeoMapData> GetToTheChopper()
            {
                return ItsNotEasyBeingChessy.Instance.GetToTheChopperGeoData();
            }
        }
    
        public class RESTService : WSDLService
        {
            // Let's move along folks, nothing to see here...
            // Seriously though - there is no need to duplicate the effort made in
            // the WSDLService class as it can be inherited and by proxy implementing 
            // the appropriate contract
        }
    }
