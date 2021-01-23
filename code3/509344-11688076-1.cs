    public override bool Equals(Object emp)
    {
        // If parameter is null return false.
        if (emp == null)
        {
            return false;
        }
         // If parameter cannot be cast to Point return false.
        Employee e = emp as Employee;
        if ((System.Object)e == null)
        {
            return false;
        }
        // Return true if the fields match
        return (Name == emp.Name) && (Age == emp.Age);
    }
