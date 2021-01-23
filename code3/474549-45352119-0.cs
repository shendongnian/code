    //Instance ID ----------------------------------------
        // Class variable holding the last assigned IID
        private static int xID = 0;
        // Lock to make threadsafe (can omit if single-threaded)
        private static object xIDLock = new object();
        // Private class method to return the next unique IID 
        //  - accessible only to instances of the class
        private static int NextIID()                    
        {
            lock (xIDLock) { return ++xID; }
        }
        // Public class method to report the last IID used 
        // (i.e. the number of instances created)
        public static int LastIID() { return xID; }
        // Instance readonly property containing the unique instance ID
        public readonly int IID = NextIID();
    //-----------------------------------------------------
