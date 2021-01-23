    public class Person
    {
        private RecIpDet _ipDet;
        public RecIpDet IpDet
        {
            get 
            {                 
                if (_ipDet == null)
                {
                    _ipDet = new RecIpDet();
                }
                return _ipDet; 
            }
        } 
    }
