    public class ViewModel : INotifyPropertyChanged
    {
        private object _selectedItem;
        public object SelectedItem
        {
            get { return _selectedItem; }
            set 
            { 
                _selectedItem = value; 
                OnPropertyChanged("SelectedItem"); 
            }
        }
    }
