    public interface IVehicleInfoRetriever {
        VehicleInfoResponse getVehicleInfo(string primaryCode);
    }
    
    public class DataManager<TVehicleInfoFetcher> 
        where TVehicleInfoFetcher : class, new(), IVehicleInfoRetriever 
    {
    
        private string _providerCode;
    
        public DataManager() : this("UK") { }
    
        public DataManager(string providerCode) {
            _providerCode = providerCode;
        }
    
        public string getUpcomingVehicleInfoNow(string stopID)
        {
            VehicleInfoFetcher infoFetcher;
            if ( shouldCheckDB(stopID))
                VehicleInfoFetcher infoFetcher = new DatabaseVehicleInfoFetcher(_providerCode);
            else 
                fetcher = new TVehicleInfoFetcher();
    
                return fetcher.getVehicleInfo(primaryCode).Result;  // This is an async method, but we wait for the result
            }
        }
    
    }
