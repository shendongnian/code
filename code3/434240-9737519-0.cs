    [Serializable]
    public class SampleClass
    {
        [Serializable]
        public class Person
        {
            [XmlElement("Name")]
            public string Name { get; set; }
    
            [XmlElement("Age")]
            public ushort Age { get; set; }
        }
    
        [Serializable]
        public class Adress 
        {
            [XmlElement("Street")]
            public string Street { get; set; }
    
            [XmlElement("HouseNumber")]
            public int Number { get; set; }
        }
    
        public SampleClass()
        { 
        }
    
        public SampleClass(string name, byte age, string street, int number)
        {
            this.Person = new Person
            {
                Age = age,
                Name = name    
            };
    
            this.Adress = new Adress
            {
                Street = street,
                Number = number
            }
        }
    
        public Person Person { get; set; }
        public Address Address { get; set; }
    }
