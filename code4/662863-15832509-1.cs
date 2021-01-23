    IList oldList = (IList)oldValue; //Visual studio complains about
    IList newList = (IList)newValue; //listType not being found
    
    if (!NonGenericSequenceEqual(oldList, newList))
    {
        changeSet.GetType().GetRuntimeProperty(property.Name).SetValue(changeSet, newValue, null);
    }
    public static bool NonGenericSequenceEqual(IList a, IList b)
    {
        if (ReferenceEquals(a, b))
        {
            return true;
        }
        else if (a == null || b == null)
        {
            return false;
        }
        else
        {
            int count = a.Count;
    
            if (count != b.Count)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (!Object.Equals(a[i], b[i]))
                    {
                        return false;
                    }
                }
    
                return true;
            }
        }
    }
