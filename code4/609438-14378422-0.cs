    class LockableList {
        public ReaderWriterLockSlim RwLock {get;private set;}
        public List<object2> Data {get;private set;}
        public LockableList() {
            RwLock = new ReaderWriterLockSlim();
            Data = new List<object2>();
        }
    }
    ...
    Dictionary<object1,LockableList> myDictionary;
