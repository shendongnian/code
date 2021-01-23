    interface ISomeInterface
    {
        string PropertyA { get; set }
        void MethodB (int x);
    }
    class TheRealObject : ISomeInterface
    {
        public string PropertyA { get; set }
        public void MethodB (int x)
        {
            Console.WriteLine(x);
        }
    }
    class Wrapper : ISomeInterface
    {
        TheRealObject _obj = new TheRealObject();
        public string PropertyA
        { 
            get { return _obj.PropertyA; }
            set { _obj.PropertyA = value; }
        }
        public void MethodB (int x)
        {
            _obj.MethodB(x);
        }
        public void CreateNewObject()
        {
            _obj = new TheRealObject();
        }
    }
