    class Person {
        [ID("A","B")]
        public Address HomeAddress
        {
            get
            {
                 System.Attribute[] attrs = System.Attribute.GetCustomAttributes(Person);
                 // use attrs[0] to get "A";
                 // use attrs[1] to get "B";
            }
            set { }
        }
    }
