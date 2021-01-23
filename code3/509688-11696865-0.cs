     private List<Person> _persons = new List<Person> 
            {
                new Person{Age=23,Name="Ram"},
                 new Person{Age=43,Name="Rahim"}
            };
 
     private Person GetPerson(int age)
            {
                return _persons.Where(p => p.Age == age).FirstOrDefault();
            }
     Person p = GetPerson(23);
                p.Name = "Hari";
