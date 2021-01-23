    class Program
    {
        static void Main(string[] args)
        {
            Object obj1 = new object();
            obj1 = "Something";
            DoSomething(obj1);
            Console.WriteLine(obj1);
            DoSomethingCreateNew(ref obj1);
            Console.WriteLine(obj1);
            DoSomethingAssignNull(ref obj1);
            Console.WriteLine(obj1 == null);
            Console.ReadLine();
        }
        public static void DoSomething(object parameter)
        {
            parameter = new Object(); // original object from the callee would be unaffected. 
        }
        public static void DoSomethingCreateNew(ref object parameter)
        {
            parameter = new Object(); // original object would be a new object 
        }
        public static void DoSomethingAssignNull(ref object parameter)
        {
            parameter = null; // original object would be a null 
        }
    }
