    var testList = testData
                      .OfType<Dictionary<string,object>>()
                      .Select(d=> new TestClass(d))
                      .ToList();
    ...
    class TestClass
    {
        public TestClass(Dictionary<string,object> data)
        {
            if(!data.ContainsKey("AAA")) 
               throw new ArgumentException("Key for field AAA does not exist.");
            AAA = data["AAA"].ToString();
    
            if(!data.ContainsKey("BBB")) 
               throw new ArgumentException("Key for field BBB does not exist.");
            BBB = data["BBB"].ToString();
    
            if(!data.ContainsKey("CCC")) 
               throw new ArgumentException("Key for field CCC does not exist.");
            CCC = data["CCC"].ToString();
        }
    
        public string AAA {get;set;}
        public string BBB {get;set;}
        public string CCC {get;set;}
    }
