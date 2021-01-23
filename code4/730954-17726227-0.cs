    foreach (var item in prop as IEnumerable)
    {
        var t1 = item as Type1;
        if(t1 != null)
        {
            //Do something
        }
        var t2 = item as DateTime?;
        if(t2.HasValue)
        {
            //Do your stuff
        }
    }
