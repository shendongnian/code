        public abstract class DataProvider : ProviderBase
        {
    
            public string MyAttribute1 { get; set; }
            public string MyAttribute2 { get; set; }
            public string MyAttribute3 { get; set; }
        
            // Define the methods to be used by the provider.  These are custom methods to your own provider.
            public abstract void Get();
            public abstract void Delete();
            public override void Initialize(string name, NameValueCollection config)
            {
                MyAttribute1 = config["MyAttribute1"];
                MyAttribute2 = config["MyAttribute2"];
                MyAttribute3 = config["MyAttribute3"];
                base.Initialize(name, config);
            }
        }
    
        
