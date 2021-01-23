    public class Foo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        string x;
        public string X
        {
            get { return x; }
            set
            {
                x = value;
                this.NotifyPropertyChanged();
            }
        }
        BindingList<FooChild> children;
        public BindingList<FooChild> Children
        {
            get { return children; }
            set
            {
                children = value;
                this.NotifyPropertyChanged();
            }
        }
    }
    public class FooChild : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        string y;
        public string Y
        {
            get { return y; }
            set
            {
                y = value;
                this.NotifyPropertyChanged();
            }
        }
    }
