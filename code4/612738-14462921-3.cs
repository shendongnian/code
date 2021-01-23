    get
    {
        if (myObject == null)
        {
            return null;
        }
        else
        {
            // not sure which index(es) you want
            int index = 0;
            Type t = myObject.GetType();
            if (typeof(IList).IsAssignableFrom(t))
            {
                IList ilist = (IList)myObject;
                return ilist[index];
            }
            else
            {
                var indexer = t.GetProperties()
                    .Where(p => p.GetIndexParameters().Length != 0)
                    .FirstOrDefault();
                if (indexer != null)
                {
                    object[] indexArgs = { index };
                    return indexer.GetValue(myObject, indexArgs);
                }
                else
                    return null;
            }
        }
    }
