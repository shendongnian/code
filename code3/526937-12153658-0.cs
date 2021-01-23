    static void Main(string[] args)
            {
                var records = GetPersonRecords();
    
                var onlyName = records.Select(i => i.Name);
            }
    
            private static List<Person> GetPersonRecords()
            {
                var listPerson = new List<Person>();
    
                listPerson.Add(new Person { Id = 1, Name = "Name1" });
                listPerson.Add(new Person { Id = 2, Name = "Name2" });
    
                return listPerson;
            }
        }
    
        class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
