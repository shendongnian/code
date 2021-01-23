    void completionHandler(string error, object result)
    {
        var hashTable = result as Hashtable;
        if (hashTable != null)
        {
            foreach (object key in hashTable.Keys)
            {
                Debug.Write(
                    String.Format("key:{0} value:{1}", 
                        key.ToString(), 
                        hashTable[key]));
            }
        }
    }
