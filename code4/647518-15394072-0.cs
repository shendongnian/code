    Sometype a = null;
    foreach(var b in someEnumerable)
    {
        if(a == null)
        {
            a = b;
        }
        else
        {
            a = a & b;
        }
    }
