    [ThreadStatic]
    private static List<string> _myList;
    public static List<string> MyList {
      get { return _myList; }
      set { _myList = value; }
    }
