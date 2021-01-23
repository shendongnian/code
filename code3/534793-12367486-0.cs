    public class MyClass
    {
        private bool _error;
        private Func<bool> DoThis;
        private Func<bool> DoThat;
        public MyClass()
        {
            DoThis = () => true;
            DoThat = () => false;
            Validate();
        }
        public void Validate()
        {
            Error = DoThis() && DoThat();
        }
        public bool Error
        {
            get { return _error;  }
            set { 
                _error = value;
                if (_error) FailoverActions();
            }
        }
        public void FailoverActions()
        {
            
        }
    }
