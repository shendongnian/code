    public class controlProperties : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Visibility _visibility;
        public Visibility VisibleState
        {
            get
            {
                return _visibility;
            }
            
            set
            {
                _visibility = value;
                this.NotifyPropertyChanged("VisibleState");
            }
        }
        public void changeVisibility(bool isVisible)
        {
            if (isVisible)
                this.VisibleState = Visibility.Visible;
            else
                this.VisibleState = Visibility.Collapsed;
        }
        private void NotifyPropertyChanged(string propertyName)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(sender, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
