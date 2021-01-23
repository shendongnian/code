    try
    {
        for (int i= 0; ; i++)
        {
            var visitor = new Visitor(array);
            for(int i = 0;; ++i)
                array[i].Accept(visitor);
        }
    }
    catch (IndexOutOfRangeException)
    { }
