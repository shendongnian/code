    public void DoSmth<T>(T obj)
        where T : Superclass
    {
        if(typeof(T).IsSubclassOf(typeof(Subclass))
        {
            Subclass obj2 = (Subclass) obj;   //untested but something like this
            DoSmth2(obj);
        }
        //...
    }
