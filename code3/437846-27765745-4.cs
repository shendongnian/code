    public class SimpleViewModel // : DomainModelBase - add your notify property changed
    {
        public SimpleViewModel()
        {
            _visible = true;
        }
        private bool _visible;
        public bool Visible
        {
            get
            {
                return _visible;
            }
            set
            {
               _visible = value;
               OnPropertyChanged("Visible");
            }
        }
    }
