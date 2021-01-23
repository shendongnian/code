    class someOtherClass
    {
        public string property1{ get; set; };
        public string property2{ get; set; };
        public string Key{ get; set; };
    }
    
    List<someOtherClass> objects = dictionary
    .Select(kv => new someOtherClass(){
         property1 = kv.Value.property1, 
         property2 = kv.Value.property2, 
         Key       = kv.Key 
     })
    .ToList();
