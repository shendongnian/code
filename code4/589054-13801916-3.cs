    public bool IsContainedWithinInOrder(IEnumerable<object> a, IEnumerable<object> b)
    {
        var iterator = a.GetEnumerator();
        foreach(var item in b)
        {
            do
            {
                if(!iterator.MoveNext())
                    return false;
            } while(!Equals(iterator.Current, item));
        }
        
        return true;
    }
