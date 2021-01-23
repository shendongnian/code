    public class Global : INotifyPropertyChanged
    {
        private string _userName;
        public string UserName
        {
            get
            {
                return this._userName;
            }
            set
            {
                if (this._userName == value)
                {
                    return;
                }
                this._userName = value;
            
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("UserName"));
                }
            {
        }
        public event PropertyChanged PropertyChanged;
        private Global() {}
        public static readonly Global Get = new Global();
    }
