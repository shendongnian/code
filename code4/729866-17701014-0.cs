        private int _testNumber;
        public int TestNumber
        {
            get { return _testNumber; }
            set
            {
                if (_testNumber != value)
                {
                    MessageBoxResult result = MessageBox.Show("Change value?", "Change Value?", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        _testNumber = value;                        
                    }
                    RaisePropertyChanged("TestNumber");
                }
            }
        }
