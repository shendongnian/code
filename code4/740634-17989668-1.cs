    class MyClass: INotifyPropertyChanged
    {
        public MyClass()
        {
            this.nameOf_MyProperty = PropertyNameExtractor.ExposeProperty(() => this.MyProperty);
        }
        private readonly string nameOf_MyProperty;
        private int myProperty = 42 ;
        public int MyProperty
        {
            get
            {
                return myProperty;
            }
            set
            {
                myProperty= value;
                NotifyPropertyChanged(nameOf_MyProperty);
            }
        }
        private void NotifyPropertyChanged(String PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
