    public class SlotViewModel : ViewModelBase
    {
        private _isChecked;
    
        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; NotifyPropertyChanged("IsChecked"); }
        }
    }
