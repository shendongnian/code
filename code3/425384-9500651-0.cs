    [DataContract(Name = "Person", Namespace = "http://www.woo.com")]
        class Person
        {
            [DataMember()]
            public string Name;
            [DataMember()]
            public int Age;        
        }
