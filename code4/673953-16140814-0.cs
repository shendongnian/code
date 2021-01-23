    get
    {
       if(_myList != null)
       { 
          Session["MyData"] = _myList;   // change
          return _myList;
       }
       if (Session["MyData"] != null)
          _myList = Session["MyData"] as List<string>;
       else
          _myList = new List<string>();
       return _myList; 
    }
    set
    {
        _myList = value;         //change
        Session["MyData"] = value;
    }
