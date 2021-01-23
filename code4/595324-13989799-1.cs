    public class Customer{
        public int ID{get;set;}
        public string Name{get;set;}
        public string LastName {get;set;}
        public Guid DepID{get;set;}
        public bool Editable{get{return SomeStruct.Check(DepID);}}
    }
