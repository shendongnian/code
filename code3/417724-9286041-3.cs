    class BasePage : Page
    {
        ...
        private MyEnum _myenum;
        ...
        
        protected MyEnum EnumProperty
        {
            get { return _myenum; }
            set { _myenum = value; }
        }
    }
