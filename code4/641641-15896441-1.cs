    public class MyService : MarshalByRefObject
        {
            public struct Person
            {
                public string name;
                public int id;
    
                public Person(int id, string name)
                {
                    this.name = name;
                    this.id = id;
                }
    
                public string getName()
                {
                    return this.name;
                }
    
                public int getId()
                {
                    return this.id;
                }
            }
            
            public string MySampleMethod()
            {
                return "This is return String";
            }
    
            public Person getPerson()
            {
                Person person = new Person(15, "Wajdy");
                return person;
            }
        }
