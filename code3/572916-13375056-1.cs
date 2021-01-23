        public MyClass Xyz
        {
            get { return _myinterface; }
            set { _myinterface = value; }
        }
    you're probably looking to return `IInterface` instead:
        public IInterface Xyz
        {
            get { return _myinterface; }
            set { _myinterface = value; }
        }
