    public static class IdGenerator
    {
        private static int _counter;
    
        public static uint GetNewId()
        {
            uint newId = unchecked ((uint) System.Threading.Interlocked.Increment(ref _counter));
            if (newId == 0)
            {
                throw new System.Exception("Whoops, ran out of identifiers");
            }
            return newId;
        }
    }
