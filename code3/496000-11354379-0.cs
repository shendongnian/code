    public class Person
        {
            protected string Name;
    
            public string WhatsYourName()
            {
                return this.Name;
            }
        }
    
        public class Mother: Person
        {
            public Mother(string personName)
            {
                this.Name = personName;
            }
        }
    
        public class Child : Person
        {
            public Mother MyMother { get; set; }
    
            public Child(string personName)
            {
                this.Name = personName;
            }
    
            public string WhoAreYou()
            {
                return string.Format("My name is {0} and my mom is {1}", this.Name, this.MyMother.WhatsYourName());
            }
        }
