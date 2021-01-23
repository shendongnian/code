    public class Service : IService
    {
        public string CallADSWebMethod(string vin, string styleID)
        {
            return vin + styleID;
        }
    }
