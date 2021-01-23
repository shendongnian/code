    private object myObject;
    public object newObject
    {
        if(myObject == null)
        {
            myObject  = new object();
        }
        return myObject;
    }
