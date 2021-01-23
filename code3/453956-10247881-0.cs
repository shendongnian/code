    public List<Employees> GetEmployees()
    {
        ..
        List<Employees> emps = new List<Employees>();
        Employees emp = null;
        while (..)
        {
            emp = new Employees();
            ..
            emps.Add(emp);
        }
        return emps;
    }
