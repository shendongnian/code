    public class Author
    {
        XElement self;
        public Author(XElement self) { this.self = self; }
    
        public int Id { get { return self.Get("id", 0); } }
        public string LastName { get { return self.Get("lname", string.Empty); } }
        public string FirstName { get { return self.Get("fname", string.Empty); } }
        public string MiddleName { get { return self.Get("mname", string.Empty); } }
    
        public override string ToString()
        {
            return FirstName + MiddleName + LastName;
        }
    }
