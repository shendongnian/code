    class ObjectProperties
    {
        public string ObjectNumber { get; set; }
        public string ObjectComments { get; set; }
        public string ObjectAddress { get; set; }
        
        public override string ToString() 
        {
            return "ObjectNumber: " 
                  + ObjectNumber 
                  + " ObjectComments: " 
                  + ObjectComments 
                  + " ObjectAddress: " 
                  + ObjectAddress;
        }
    }
