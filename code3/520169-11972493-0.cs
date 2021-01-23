    public MyObjectViewModel MyObject            {
                get { return myObject; }
                set
                {
                    myObject=null;
                    OnPropertyChanged("MyObject");
    
                    myObject= value;
                    OnPropertyChanged("MyObject");
                }
            }
