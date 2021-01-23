    class MyContractResolver : CamelCasePropertyNamesContractResolver
    {
        public MyContractResolver()
        {
            NamingStrategy.OverrideSpecifiedNames = false;    //Overriden
            NamingStrategy.ProcessDictionaryKeys = false;     //Overriden
            NamingStrategy.ProcessExtensionDataNames = false; //default
        }
    }
