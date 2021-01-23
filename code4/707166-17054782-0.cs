    class MyOtherClass
    {
        public MyOtherClass(int xMAx, int yMax)
        {
            MyProperty = new int[xMAx, yMax];
        }
        public int[,] MyProperty { get; private set; }
    }
