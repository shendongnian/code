     public class MainViewModel : INotifyPropertyChanged
            {
                public event PropertyChangedEventHandler PropertyChanged;
                private void OnPropertyChanged(string propertyName)
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    }
                }
        
                private string _selectedDifStatusComparer = "";
                public string SelectedDifStatusComparer
                {
                    get { return _selectedDifStatusComparer; }
                    set
                    {
                        _selectedDifStatusComparer = value;
                        MessageBox.Show(_selectedDifStatusComparer);
                        OnPropertyChanged("SelectedDifStatusComparer");
                    }
                }
        
                public MainViewModel()
                {
                    SelectedDifStatusComparer = "E"; // It is working, the MessageBox is apperaing
                }
            }
