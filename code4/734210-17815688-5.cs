    class Program
    {
        static void Main(string[] args)
        {
            Method1<Employee>();
            Method1<Supplier>();
        }
        private static void Method1<T1>()
            where T1 : IContractor, new()
        {
        }
    }
    public class Supplier : IContractor
    {
        string IContractor.Name
        {
            get{return "Supplier-Mufflier";}
        }
    }
    public class Employee : IContractor
    {
        string IContractor.Name
        {
            get{return "Employee-Merloyee";}
        }
    }
    public interface IContractor
    {
        string Name
        {
            get;
        }
    }
