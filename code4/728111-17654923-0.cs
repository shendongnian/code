    this is because you have not implement the inotifypropertychange on you avatar class so for doinng that just do like this..
    public class Assignment  : INotifyPropertyChanged
    {
       
   
        private Visibility _ImgVis ;
        public Visibility ImgVis 
        {
            get
            {
                return _ImgVis ;
            }
            set
            {
                _ImgVis  = value;
                FirePropertyChanged("ImgVis ");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void FirePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
