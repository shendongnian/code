    public class ViewModel:INotifyPropertyChanged
        {
            public ObservableCollection<Control> MyItemsSource { get; set; }
            public ViewModel()
            {
                MyItemsSource = new ObservableCollection<Control> {new ListBox(), new TextBox()};
            }
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string name)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
            }
        }
