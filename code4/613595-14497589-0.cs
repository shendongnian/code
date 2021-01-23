        public class Item: INotifyPropertyChanged
        {
            private bool isChecked;
            public event PropertyChangedEventHandler PropertyChanged;
            public bool IsChecked
            {
                get
                {
                    return this.isChecked;
                }
                set
                {
                    this.isChecked = value;
                    var propertyChangedEvent = PropertyChanged;
                    if(propertyChangedEvent != null)
                    {
                        propertyChangedEvent(this, new PropertyChangedEventArgs("UpdateSomething");
                    }                
                }
            }
        }
        public class MyViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public ICommand UpdateSomething { get; private set; }
            public ObservableCollection<Item> MyItems { get; set; }
            public MyViewModel()
            {
                UpdateSomething = new RelayCommand(MyCommandExecute, MyCommandCanExecute);
                MyItems = new ObservableCollection<Item>();
            }
            private void MyCommandExecute(object parameter)
            {
                // Your logic here.
            }
            private void MyCommandCanExecute(object parameter)
            {
                return MyItems.Any(item => item.IsChecked);
            }
            private void AddItem(Item item)
            {
                item.PropertyChanged += ItemsPropertyChanged;
                MyItems.Add(item);
            }
            private void ItemsPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                var propertyChangedEvent = PropertyChanged;
                if(propertyChangedEvent != null &&
                   e.PropertyName == "IsChecked")
                {
                    propertyChangedEvent(this, new PropertyChangedEventArgs("UpdateSomething");
                }                
        }
