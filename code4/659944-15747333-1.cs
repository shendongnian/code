    public Foo F
    {
        get{return foo;}
        set
        {
            if( foo != null)
                foo.Dispose();
            foo = value;
         }
    }
