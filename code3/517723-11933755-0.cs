     private Dictionary<long, string> _myList = new Dictionary<long, string>();
     public Dictionary<long, string> MyList {
          get { return _myList; }
          set { _myList = value;
                PropertyChanged("MyList"); }
     }
     
     public void Init() {
          _myList.Add(1, "One");
     }
