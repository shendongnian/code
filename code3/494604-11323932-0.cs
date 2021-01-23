    abstract class classA
    {
        abstract public void MethodA();
        public void MethodB()
        {
            Console.WriteLine("This is MethodB inside ClassA");
        }
    }
    class classB : classA
    {
        public override void MethodA()
        {
            Console.WriteLine("This is MethodA inside class B");
        }
    }
