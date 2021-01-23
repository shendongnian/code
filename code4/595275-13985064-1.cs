    public class ExampleClass
    {
        public Action<int> Do { get; set; }
        public ExampleClass(bool useA)
        {
            if (useA)
                Do = FuncA;
            else
                Do = FuncB;
        }
        public void FuncA(int n)
        {
            //irrelevant code here
        }
        public void FuncB(int n)
        {
            //other irrelevant code here
        }
    }
