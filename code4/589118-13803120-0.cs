    class Main
    {
        public delegate int DelegateType(string x);
        public int SomeFunction(string y) { return int.Parse(y)*2; }
        public void Main()
        {
            DelegateType delegateInstance = null;
            delegateInstance = SomeFunction;
            int z = delegateInstance("21");
            Console.WriteLine(z);
        }
    }
