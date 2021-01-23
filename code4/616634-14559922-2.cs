    private int someInt;
    public int RetInt
    {
        get
        {
            if (someInt > 0)
                return someInt;
            else
                return -1;
        }
        set { someInt = value; } // same kind of check /validation can be done here
    }
