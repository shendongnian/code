    public class Test
    {
        private string _mystr;
        private Action<string> _action;
        public Test(Action<string> action)
        {
            _action = action;
        }
        // Let's make mystr a property
        public string mystr
        {
            get { return _mystr; }
            set
            {
                _mystr = value;
                _action(_mystr);
            }
        }
    }
