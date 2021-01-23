    public class MyModel
    {
        private string _myProp
    
        public string MyProp
        {
            set { _myProp = value.Trim(); }
            get { return _myProp; }
        }
    }
