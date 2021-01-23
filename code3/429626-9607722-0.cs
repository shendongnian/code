    public class test
    {
        private string[] _textBoxes;
        // constructor
        public test()
        {
            _textBoxes = new string[30];
        }
        // bind your textboxes to a bunch
        // of properties
        public string Property0
        {
            get
            {
                return _textBoxes[0];
            }
            set
            {
                _textBoxes[0] = value;
                OnPropertyChanged("Property0");
            }
        }
    }
