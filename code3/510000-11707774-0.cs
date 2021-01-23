        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.450")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [XmlRoot("person")]
        public class Person
        {
            public Person() { }
            public Person(int id, string firstName, string lastName)
            {
                Id = id;
                FirstName = firstName;
                LastName = lastName;
            }
            [XmlAttribute]
            public int Id { get; set; }
            [XmlAttribute]
            public string FirstName { get; set; }
            [XmlAttribute]
            public string LastName { get; set; }
            [XmlArray("children")]
            [XmlArrayItem("person")]
            public Person[] Children { get; set; }
        }
