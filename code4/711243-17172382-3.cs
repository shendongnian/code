    public class MyWCFService : MyServiceProject.ServiceRouter
    {
        public MyWCFService() : base(null)
        { 
            // Since the WCF server is running on the local area network, this class only needs to create an instance of 
            // the service router in local mode and retrive the requested data.  WCF serializes the data and sends it
            // back over the wire.
        }
    }
