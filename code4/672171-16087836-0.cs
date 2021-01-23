    Interface ITest
    {
       void AddPerson(string name, string age);
    }
    
    /// This must expose the AddPerson method
    class Example : ITest
    {
       string name_;
       string age_;
       void AddPerson(string name, string age)
       {
          name_ = name;
    	  age_ = age;
       }
    }
