    public static bool IsContainedWithinInOrder<T>(this IEnumerable<T> values,
                                                   IEnumerable<T> reference)
    {
        using(var iterator = reference.GetEnumerator())
        {
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
    }
