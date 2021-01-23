    public static class Person {
        private readonly object syncLock = new object();
        
        public static void Insert(Person p) {
            lock(syncLock) {
                //...
            }
        }
        
        // etc...
    }
