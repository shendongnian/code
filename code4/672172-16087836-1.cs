    Interface ITest
    {
       void AddPerson(string name, string age);
    }
    
    Interface IPerson
    {
    	string ReturnPersonsAge(string name);
    }
    
    /// This must expose the AddPerson method
    /// This must also expose the ReturnPersonByAge method
    class Example : ITest, IPerson
    {
       Dictionary<string, string> people = new Dictionary<string, string>();
       
       void AddPerson(string name, string age)
       {
          people.Add(name, age);
       }
       
       string ReturnPersonsAge(string name)
       {
    	  return people[name];
       }
    }
