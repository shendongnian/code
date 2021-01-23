    public class CodeClass
    {
        private string _someString;
        public string SomeString 
        {
            get { return _someString; }
            set 
            {
                _someString = value;
                if (SomeStringChanged != null) { SomeStringChanged(value) }
            }
        }
        public event Action<string> SomeStringChanged;
    }
