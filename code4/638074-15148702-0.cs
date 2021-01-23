    public class VerifyViewModel : INotifyPropertyChanged
    {
        public VerifyViewModel(string content)
        {
            this.TBText = content;
        }
        public string TBText { get; private set; }
        #region INPC code - can create an abstract base view model class and put this there instead
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion
    }
