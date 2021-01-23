    public class Person
    {
        private Lazy<RecIpDet> _ipDet = new Lazy<RecIpDet>();
    
        public RecIpDet IpDet
        {
            get { return _ipDet.Value; }
        } 
    }
