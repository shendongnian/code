    //Note: I marked it as partial because there may be other code not showed here
    // in particular I will not write the method GetConnection again. That said...
    // you can have it all in a single block in a single file without using partial.
    public partial class YourClass
    {
        private dynamic _serviceObject;
        
        private void Store(dynamic serviceObject)
        {
            _serviceObject = serviceObject;
        }
        public dynamic ServiceObject
        {
            get
            {
                return _serviceObject;
            }
        }
    }
