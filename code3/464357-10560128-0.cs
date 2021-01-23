    class MethodAParameters
    {
        public string Required1 {get;set;} //add validation in setter (nulls are not allowed)
        public string Required2 {get;set;} //add validation in setter (nulls are not allowed)
        public int? Optional1 {get;set;} //nulls allowed
    
        public MethodAParameters(string required1, string required2)
        {
            Required1 = required1;
            Required2 = required2;
        }
    }
