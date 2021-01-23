    public class Product : INotifyPropertyChanged
    {
        private bool _selected;
        private string _product;
        public event PropertyChangedEventHandler PropertyChanged;
        public Product(string product)
        {
            _selected = true;
            _product = product;
        }
        public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                this.NotifyPropertyChanged("Selected");
            }
        }
        public string ProductName
        {
            get { return _product; }
            set
            {
                _product = value;
                this.NotifyPropertyChanged("Product");
            }
        }
        
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
