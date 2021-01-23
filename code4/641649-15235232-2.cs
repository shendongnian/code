    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool isItemVisible;
        public bool IsItemVisible { get { return isItemVisible; } set { isItemVisible = value; OnPropertyChanged("IsItemVisible"); } }
        public ViewModel()
        {
            this.IsItemVisible = true;
        }
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
