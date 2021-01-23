    class SampleCollection<T>
    {
        // Define the indexer, which will allow client code 
        // to use [] notation on the class instance itself. 
        public T this[int i] { /* ... */ }
    }
    
    // Usage:
    SampleCollection<string> stringCollection = new SampleCollection<string>();
    stringCollection[0] = "Hello, World";
