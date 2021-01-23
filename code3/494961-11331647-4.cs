    public abstract class AbstractLibraryClassY
    {
        private static int _multiplier = 0;
        public abstract int MethodA(int SomeParam);
        
        // A simple example Property defined and implemented on the Abstract base class:
        public int Multiplier
        {
            get { return _multiplier; }
            set { _multiplier = value; }
        }
        private void someclassYImplementationStuff()
        {
            // Other implementation code . . .
        }
    }
