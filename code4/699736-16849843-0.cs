    public class A : INotifyPropertyChanged
    {
        int _c = 0;
    
        public int p1 //this is child property
        {
            get { return _c; }
            set 
            {
                if(_c != value)
                {
                     OnNotifyPropertyChanged("p1");
                     _c = value;
                } 
            } 
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void OnNotifyPropertyChanged(string propertyName)
        {
           var tmp = PropertyChanged;
           if (tmp != null)
           {
              tmp (this, new PropertyChangedEventArgs(propertyName));
           }
        }
    }
    public class B
    {
        Public B()
        {
           _a = new A();
           _a.PropertyChanged += AChanged;
        }
        A _a;
        private AChanged(object o, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "p1")
            {
                //do your work here on change
            }
        }
    
        public A p2  //this is parents property
        {
            get { return _a; }
            set { _a = value; }
        }
    }
