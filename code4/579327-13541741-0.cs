    public class ItemViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        private bool isSelected;
        public bool IsSelected {
            get { return this.isSelected; }
            set
            {
                if (this.isSelected == value)
                    return;
                this.isSelected = value;
                this.OnPropertyChanged("IsSelected");
            }
        }
        private string myProperty;
        public string MyProperty
        {
            get { return this.myProperty; }
            set
            {
                if (this.myProperty != value)
                {
                    this.myProperty = value;
                    this.OnPropertyChanged("MyProperty");
                }
            }
        }
    }
