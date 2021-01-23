    [ServiceContract]
    public interface IWirelessService : IInternetService
    {
        [OperationContract]
        Connection AddInternet();
    }
    [ServiceContract]
    public interface IWiredService : IInternetService
    {
        [OperationContract]
        Connection AddInternet();
    }
    public class WirelessService : IWirelessService 
    {
       public Connection AddInternet()
       {
	   //Get Internet the wireless way
       }
    }
    public class WiredService : IWiredService 
    {
        public Connection AddInternet()
        {
	    //Get Internet the wired way
        }
    }
    [ServiceContract]
    public interface IInternetService
    {
        [OperationContract]
        Connection AddInternet();
    }
    [ServiceContract]
    public interface IEnterpriseApplicationService
    {
        [OperationContract]
        void GetDataFromInternet(string url, IInternetService internetService);
    }
    public class InternetProviderService : IEnterpriseApplicationService
    { 
        public HTMLResponse GetDataFromInternet(string url, IInternetService internetService)
        {
           Connection con = internetService.AddInternet();
           return con.GetContentFromURL(url);
        }
     }
