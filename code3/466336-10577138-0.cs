    class MyClass
    {
        private List<string> _list = new List<string>();
        public MyClass()
        {
            //some logic here
        }
        public MyClass(List<string> initialList) : this()
        {
            _list = initialList;
        }
    }
