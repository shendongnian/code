     private Dictionary<long, string> _myList = new Dictionary<long, string>();
     public Dictionary<long, string> MyList {
          get { return _myList; }
          set { _myList = value;
                PropertyChanged("MyList"); }
     }
     
     public void Init() {
          Dictionary<long, string> tempList = new Dictionary<long, string>();
          tempList.Add(1, "One");
          MyList = tempList;
     }
