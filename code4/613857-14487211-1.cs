    public interface IEmployeeAdapter
    {
        string Age { get; set; }
        string Name { get; set; }
    }
    
    class EmployeeTypeAAdapter : TypeA, IEmployeeAdapter
    {
    }
    
    class EmployeeTypeBAdapter : TypeB, IEmployeeAdapter
    {
    }
    
    public static class EmployeeAdapterFactory
    {
        public static IEmployeeAdapter CreateAdapter(object employee, EmployeeType type)
        {
            switch (type)
            {
                // return EmployeeTypeAAdapter or EmployeeTypeBAdapter
            }
        }
        // or without enum
        public static IEmployeeAdapter CreateAdapter(object employee)
        {
            if (employee is TypeA) return new EmployeeTypeAAdapter((TypeA)employee);
            if (employee is TypeB) return new EmployeeTypeABdapter((TypeB)employee);
        }
    }
