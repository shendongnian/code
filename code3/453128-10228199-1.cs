    class Parent
    {
        Parent _child;
      
        public Parent(Parent child)
        {
            _child = child;
        }
        public void ChangeChild(Parent child)
        {
            _child = child;
        }
        public string AProperty {
            get { return _child.AProperty; }
            set { _child.AProperty = value; }
        }
        public int AMethod(int x)
        {
            return _child.AMethod(x);
        }
    }
