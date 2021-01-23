     public class BaseClass
    {
        public string FirstName = "Base Class";
        public string LastName = "Base Class";
    }
    public class DerivedClass : BaseClass
    {
        public DerivedClass()
        {
            base.LastName = "Derived Class";
        }
    }
    internal class Tester
    {
        private static void Main(string[] args)
        {
            BaseClass objBaseClass = new BaseClass();
            Console.WriteLine("First Name : " + objBaseClass.FirstName);
            Console.WriteLine("Last Name : " + objBaseClass.LastName);
            DerivedClass objDerivedClass = new DerivedClass();
            Console.WriteLine("First Name : " + objDerivedClass.FirstName);
            Console.WriteLine("Last Name : " + objDerivedClass.LastName);
            BaseClass objBaseDerivedClass = new DerivedClass();
            Console.WriteLine("First Name : " + objBaseDerivedClass.FirstName);
            Console.WriteLine("Last Name : " + objBaseDerivedClass.LastName);
            Console.ReadKey();
        }
    }
