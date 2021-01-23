    public class MyObject
    {
        private int _myID;
    
        public int MyID
        {
            get { return _myID; }
            set { _myID = value; }
        }
        private string _myString;
    
        public string MyString
        {
            get { return _myString; }
            set { _myString = value; }
        }
        private ICommand _myCommand;
    
        public ICommand MyCommand
        {
            get { return _myCommand; }
            set { _myCommand = value; }
        }
    }
