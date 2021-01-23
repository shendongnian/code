    class Person
    {
        public int Person_ID {get;set;}
        public string name {get;set;}
        public string family {get;set;}
        public int address {get;set;}
        public string name_address { get {return this.ToString();}}
        
        public override string ToString()
        {
            return string.Format("{0} {1}", this.name, this.address);
        }
    }
