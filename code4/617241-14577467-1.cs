    void completionHandler(string error, object result)
    {
        var hashTable = result as Hashtable;
        if (hashTable != null)
        {
            foreach (object key in hashTable.Keys)
            {
                System.Diagnostics.Debug.Write(key.ToString());
            }
        }
    }
