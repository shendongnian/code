        public class MyEventArgs : EventArgs
        {
            private readonly string _myFirstString;
            private readonly string _mySecondString;
            public MyEventArgs(string myFirstString, string mySecondString)
            {
                _myFirstString = myFirstString;
                _mySecondString = mySecondString;
            }
            public string MyFirstString
            {
                get { return _myFirstString; }
            }
            public string MySecondString
            {
                get { return _mySecondString; }
            }
        }
