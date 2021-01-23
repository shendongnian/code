    public int Count(object obj)
    {
        if(obj is A)
        {
            conn.table<A>.....
        }
        else if(obj is B)
        {
            conn.table<B>.....
        }
        ...
    }
