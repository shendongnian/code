    public List<int> ListOfInts
    {
        get { return _listOfInts ?? (_listOfInts = new List<int>()); }
        set { _listOfInts = value; }
    }
