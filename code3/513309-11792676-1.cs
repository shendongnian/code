        public class AddressViewModel
        {
            private readonly Address _address;
            public AddressViewModel(Address address)
            {
                _address = address;
            }
            public string Number 
            { 
                get { return _address.Number; }
                set { _adress.Number = value; }
            }
            public string Street
            { 
                get { return _address.Street; }
                set { _adress.Street = value; }
            }
        }
