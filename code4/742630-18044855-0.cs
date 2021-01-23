        public class People : DictionaryBase
        {
            public void Add(string key, Person newPerson)
            {
                Dictionary.Add(key , newPerson);
            }
    
            public void Remove(string name)
            {
                Dictionary.Remove(name);
            }
    
            public Person this[string name]
            {
                get
                {
                    return (Person)Dictionary[name];
                }
                set
                {
                    Dictionary[name] = value;
                }
            }
        }
        public class Person
        {
            private string name;
            private int age;
    
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            public int Age
            {
                get
                {
                    return age;
                }
                set
                {
                    age = value;
                }
            }
        }
