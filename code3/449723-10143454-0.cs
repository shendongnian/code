    public class MyString
    {
        private string _myString;
        public string Text
        {
            get { return _myString; }
            set { _myString = value; }
        }
        public MyString(string str)
        {
            _myString = str;
        }
    }
