    private ReadOnly object _lockMyList = new object();
    private List _MyList;
    public void SetMyList(List lst) //Use this to set list from other thread.
    {
        Lock(_lockMyList)
        {
            _MyList = lst;
        }
        //Invoke Property Changed event if needed for binding.
    }
    public List MyList
    {
        get
        {
            List lst = null;
            Lock(_lockMyList)
            {
                lst = _MyList; //You might need to do _MyList.ToList() for true thread safety
            }
            return lst;
        }
        //Property setter if needed, but use accessor method instead for setting property from other thread
    }
