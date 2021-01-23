    public class Employee 
    {
        public virtual void InitFromDataReader(DataReader dr) { }
    }
    
    public class EmployeeDetails : Employee
    {
        public override void InitFromDataReader(DataReader dr) { }
    }
    public static TEmployee LoadEmployee<TEmployee>(int id) where TEmployee : Employee, new()
    {
        using (DataReader dr = new DataReader()) 
        {
            var result = new TEmployee();
            result.InitFromDataReader(dr);
            return result;
        }
    }
