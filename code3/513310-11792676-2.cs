        public static class AddressList
        {
            private static List<Address> _backend;
            private static AddressList()
            {
                _backend = new List<Address>();
            }
            public static List<Address> GetAddressList()
            {
                if(_backend.Count == 0)
                {
                    //Here you can load your models from your data source
                }
                else
                {
                    return _backend;
                }
            }
        }
