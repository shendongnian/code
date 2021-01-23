    public class MyClass : INotifyPropertyChanged
    {
        private int _id;
        private string _value;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Id"));
                _id = value;
            }
        }
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                _value = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = new PropertyChangedEventHandler(OnPropertyChanged);
        private static void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // optional code logic
        }
    }
