    public class Class2
    {
        private Class1 instance1 = new Class1();
        public Class2()
        { 
            instance1.Variable = 50;
        }
        public void Print()
        {
             // Using the same instance - will print 50
            Console.WriteLine("Instance value is {0}", instance1.Variable);
        }
