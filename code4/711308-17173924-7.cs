    public partial class MyEntity
    {
        private AddressList _addresses;
    
        public IList<IPAdress> Adresses
        {
            get
            {
                if (_addresses == null)
                {
                    _addresses = new AddressList(HostList);
                    //When the list is modified, you want to update your property.
                    _addresses.OnModified += delegate(object sender, EventArgs e)
                    {
                        HostList = ((AddressList) sender).Serialized;
                    };
                }
                return _adresses;
            }
        }
    }
