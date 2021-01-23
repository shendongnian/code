    public class Person
    {
       public Person() 
       {
          this._address = new List<Address>();
          this.Complete_Add = new List<Address>();
       }
        public string Name { get; set; }
        public string Skillset { get; set; }
        public List<Address> _address;
        public List<Address> Complete_Add
        {
            get { return _address; }
            set { _address = value; }
        }
    }
