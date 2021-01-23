    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate{};
        protected void OnPropertyChanged(string propertyName)
        {
              PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
