    public class ManagedNetworkInterface : NetworkInterface
    {
        private NetworkInterface ni;
    
        public override string Description
        {
            get { return ni.Description; }
        }
    
        //ect...
    }
