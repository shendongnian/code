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
                // not sure what you want
                object[] indexArgs = { 0 };
                return indexer.GetValue(myObject, indexArgs);
            }
            else
                return null;
        }
    }
