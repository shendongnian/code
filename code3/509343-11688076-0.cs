    public override bool Equals(Employee emp)
    {
        if (emp == null)
        {
            return false;
        }
        // Return true if the fields match
        return (Name == emp.Name) && (Age == emp.Age);
    }
