    public List<Employee> ShowAllData(List<string> LstID)
    {
            var q = from P in Bank.employee
                    where LstID.Contains(P.Id)
                    select new Employee
                    {
                           family = P.Family,
                           name   = P.Name,
                           ...
                   };
            return q.ToList();
    }
