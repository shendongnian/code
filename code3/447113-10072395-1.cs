    public void DoSmth<T>(T obj)
        where T : Superclass
    {
       //untested but something like this
        Subclass obj2 = (obj as Subclass);   
        if(obj2 != null)
        {
            DoSmth2(obj2);
        }
        //...
    }
