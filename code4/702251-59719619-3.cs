    class ViewModelClass : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string name)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
            private ObservableCollection<StringObject> _List = new ObservableCollection<StringObject>();
            public ObservableCollection<StringObject> List
            {
                get { return _List; }
                set
                {
                    _List = value;
                    NotifyPropertyChanged("List");
                }
            }
            public ViewModelClass()
            {
                List = new ObservableCollection<StringObject>
                    {
                        new StringObject {Value = "your"},
                        new StringObject {Value = "list"},
                        new StringObject {Value = "of"},
                        new StringObject {Value = "string"}
                    };
            }
        }
        public class StringObject
        {
            public string Value { get; set; }
        }
