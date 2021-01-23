    public void doSomethingToObjectInCollection(object key, List<object> haystack)
    {
        // First find it in the collection
        object foundValue;
        for( int i = 0; i < haystack.Count; i++ )
        {
            if( haystack[i].KeyField == key )
                foundValue = key;
        }
        if( foundValue != null )
        {
            // Do something here if there was a foundValue
        }
    }
