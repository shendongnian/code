    public class Test : ViewModelBase
    {
        public int Id { get; set; }
        private TestEnum _testEnum;
        private string _testValue = "Testing";
        private double _testNumber = 10000;
        private bool _testBool;
        private bool _testBool2;
        private ObservableCollection<int> _someCollection;
        public ObservableCollection<int> SomeCollection
        {
            get
            {
                if (_someCollection == null)
                    _someCollection = new ObservableCollection<int>();
                return _someCollection;
            }
        }
        public Test()
        {
            //this.ValidatedProperties.Add("TestValue");
            //this.ValidatedProperties.Add("TestNumber");
            SomeCollection.Add(1);
            SomeCollection.Add(2);
            SomeCollection.Add(3);
        }
        public override string ToString()
        {
            return TestValue;
        }
        public void RaisePropertyChanged1(string property)
        {
            base.RaisePropertyChanged(property);
        }
        //public override string GetValidationError(string propertyName)
        //{
        //    // If user specified properties to validate, check to see if this one exists in the list
        //    if (ValidatedProperties.IndexOf(propertyName) < 0)
        //    {
        //        return null;
        //    }
        //    string s = base.GetValidationError(propertyName); ;
        //    switch (propertyName)
        //    {
        //        case "TestValue":
        //            s = "error";
        //            break;
        //    }
        //    return s;
        //}
        public TestEnum TestEnum
        {
            get { return _testEnum; }
            set
            {
                if (value != _testEnum)
                {
                    _testEnum = value;
                    base.RaisePropertyChanged(() => this.TestEnum);
                }
            }
        }
        private ObservableCollection<int> _test;
        public ObservableCollection<int> Test1
        {
            get
            {
                if (_test == null)
                {
                    _test = new ObservableCollection<int>();
                    for (int i = 0; i < 5; i++)
                    {
                        _test.Add(i);
                    }
                }
                return _test;
            }
            set
            {
                if (value != _test)
                {
                    _test = value;
                    RaisePropertyChanged(() => this.Test1);
                }
            }
        }
        public string TestValue
        {
            get { return _testValue; }
            set
            {
                if (value != _testValue)
                {
                    _testValue = value;
                    base.RaisePropertyChanged(() => this.TestValue);
                }
            }
        }
        public bool TestBool
        {
            get { return _testBool; }
            set
            {
                if (value != _testBool)
                {
                    _testBool = value;
                    base.RaisePropertyChanged(() => this.TestBool);
                }
            }
        }
        public bool TestBool2
        {
            get { return _testBool2; }
            set
            {
                if (value != _testBool2)
                {
                    _testBool2 = value;
                    base.RaisePropertyChanged(() => this.TestBool);
                }
            }
        }
        public double TestNumber
        {
            get { return _testNumber; }
            set
            {
                if (value != _testNumber)
                {
                    _testNumber = value;
                    base.RaisePropertyChanged(() => this.TestNumber);
                }
            }
        }
    }
