    public class Person
    {
        XElement self;
        public Person(XElement person) { self = person; }
    
        // Age should be a value of Now minus DOB in years.
        public int Age { get { return DateTime.Now.Year - DOB.Year; } }
    
        public DateTime DOB
        {
            get { return self.Get("DOB", DateTime.MinValue ); } // choose a default date that works for you
            set { self.Set("DOB", value, true); } // true set as attribute
        }
    
        public string FirstName
        {
            get { return self.Get("FirstName", string.Empty); }
            set { self.Set("FirstName", value, false); } // false set as child node
        } 
    
        public string LastName
        {
            get { return self.Get("LastName", string.Empty); }
            set { self.Set("LastName", value, false); }
        } 
    
        public Children Children
        {
            get { return new Children(self.GetElement("Children")); }
        }
    }
    
    public class Children
    {
        XElement self;
        public Children(XElement children) { self = children; }
        public Child this[string name]
        {
            get 
            { 
                return self.Elements("Name")
                             .Select(x => new Child(x))
                             .FirstOrDefault(c => c.Name == name);
            }
        }
    
        public Child this[int index]
        {
             get { return new Child(self.Elements("Name").ElementAt(index)); }
        }
    
        public void Add(string name)
        {
             Child child = this[name];
             if(null == child)
             {
                 child = new Child(new XElement("Name"));
                 child.Name = name;
                 self.Add(child.self);
             }
             else
                 throw new ArgumentException("Child with name: "+ name +" already exists!");
        }
    }
    
    public class Child
    {
        internal XElement self;
        public Child(XElement child) { self = child; }
    
        // You can have an Age/DOB for the child as well, or remove these two properties.
        // Age should be a value of Now minus DOB in years.
        public int Age { get { return DateTime.Now.Year - DOB.Year; } }
    
        // DOB is an attribute as self.Value in Name erases all child nodes when set.
        public DateTime DOB
        {
            get { return self.Get("DOB", DateTime.MinValue ); } // choose a default date that works for you
            set { self.Set("DOB", value, true); }
        }
    
        public string Name
        {
            get { return self.Value }
            set { self.Value = value; }
        } 
    }
