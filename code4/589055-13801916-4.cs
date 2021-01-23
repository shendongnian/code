    public static bool IsContainedWithinInOrder(this IEnumerable<object> values,
                                                IEnumerable<object> reference)
    {
        var iterator = reference.GetEnumerator();
        foreach(var item in values)
        {
            do
            {
                if(!iterator.MoveNext())
                    return false;
            } while(!Equals(iterator.Current, item));
        }
        
        return true;
    }
