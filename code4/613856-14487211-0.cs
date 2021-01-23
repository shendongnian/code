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
    
    public static class EmployeeFactory
    {
        public static IEmployeeAdapter GetEmployee(EmployeeType type)
        {
            switch (type)
            {
                // return EmployeeTypeAAdapter or EmployeeTypeBAdapter
            }
        }
    }
