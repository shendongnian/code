    get
    {
        if (myObject == null)
        {
            return null;
        }
        else
        {
            Type t = myObject.GetType();
            var indexer = t.GetProperties()
                .Where(p => p.GetIndexParameters().Length != 0)
                .FirstOrDefault();
            if (indexer != null)
            {
                return indexer.GetValue(myObject, null);
            }
            else
                return null;
        }
    }
