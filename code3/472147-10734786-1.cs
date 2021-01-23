    public void DoSomething(Employee employee)
    {
        // here we do something with an employee
        // ...
    
        string fullName = GetTheirFullName(employee);
    }
    
    public string GetTheirFullName(Person person)
    {
        return (person.FirstName + " " + person.LastName).Trim();
    }
