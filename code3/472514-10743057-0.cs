    class Program
    {
        static void Main(string[] args)
        {
            IMyClass myA = new ClassA{ Property = "Class A" };
            Console.WriteLine(myA.Property);
            
            // can't do this
            // myA.Property = "New Property"; 
            
            // can do this
            (myA as ClassA).Property = "New Property"; 
            Console.WriteLine(myA.Property);
        }
    }
    interface IMyClass
    {
        string Property { get; }
    }
    class ClassA : IMyClass
    {
        public string Property { get; set; }
    }
