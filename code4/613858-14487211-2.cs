    public interface IEmployeeAdapter
    {
        string Age { get; set; }
        string Name { get; set; }
    }
    
    class EmployeeTypeAAdapter : TypeA, IEmployeeAdapter
    {
        public EmployeeTypeAAdapter(TypeA employee) { }
    }
    
    class EmployeeTypeBAdapter : TypeB, IEmployeeAdapter
    {
        public EmployeeTypeBAdapter(TypeB employee) { }
    }
    
    public static class EmployeeAdapterFactory
    {
        public static IEmployeeAdapter CreateAdapter(object employee, EmployeeType type)
        {
            switch (type)
            {
                case EmployeeType.TypeA: return new EmployeeTypeAAdapter((TypeA)employee);
                case EmployeeType.TypeB: return new EmployeeTypeBAdapter((TypeB)employee);
            }
        }
        // or without enum
        public static IEmployeeAdapter CreateAdapter(object employee)
        {
            if (employee is TypeA) return new EmployeeTypeAAdapter((TypeA)employee);
            if (employee is TypeB) return new EmployeeTypeABdapter((TypeB)employee);
        }
        // or better introduce sort of type map
    }
