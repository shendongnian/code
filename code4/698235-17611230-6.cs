    public class MyClass
    {
        public static List<MyClassPropertyTuple> Relationships
            = new List<MyClassPropertyTuple>
                {
                    new MyClassPropertyTuple(c => c.EmployeeId, c => c.EmployeeNumber)
                };
    }
