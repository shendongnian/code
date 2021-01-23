     public class PresentationModel : INotifyPropertyChanged
    {
        private object _userPropertyA;
        public object UserPropertyA
        {
            get { return _userPropertyA; }
            set
            {
                _userPropertyA = value;
                //Set the data source based on the value of the selected?
                DataSource = new List<object>();
            }
        }
        private object _userPropertyB;
        public object UserPropertyB
        {
            get { return _userPropertyB; }
            set
            {
                _userPropertyB = value;
                //Set the data source based on the value of the selected?
                DataSource = new List<object>();
            }
        }
        public List<object> DataSource { get; set; }
        #region Implementation of INotifyPropertyChanged
        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
