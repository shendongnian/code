    void ScanCollection(object[] collection)
    {
        foreach (object item: collection)
        {
            if (item is string)
            ///Treat as string
            else if (item is float)
            ///Treat as float
            else if (item is SomethingElse)
            ///Treat as SomethingElse class
    
        }
    }
