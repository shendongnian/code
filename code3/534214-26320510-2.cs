    public class ThreadSafeBitArray
    {
        private static int[] _cachedShifts;
        static ThreadSafeBitArray()
        {
            _cachedShifts = new int[32];
            for (int index = 0; index < 32; index++)
            {
                _cachedShifts[index] = ((int)1 << index);
            }
        }
        private int _length;
        private int[] _arr;
        public ThreadSafeBitArray(int length)
        {
            _length = length;
            _arr = new int[ToUnderlineLength(length)];
        }
        private int ToUnderlineLength(int length)
        {
            int underlineLength = length / 32;
            if (length % 32 != 0)
            {
                underlineLength++;
            }
            return underlineLength;
        }
        public int Length
        {
            get { return _length; }
        }
        public bool this[int index]
        {
            get
            {
                return (Interlocked.CompareExchange(ref _arr[index >> 5], 0, 0) & (_cachedShifts[index & 31])) != 0;
            }
            set
            {
                int prevValue;
                if (value)
                {
                    do
                    {
                        prevValue = Interlocked.CompareExchange(ref _arr[index >> 5], 0, 0);
                    }
                    while (Interlocked.CompareExchange(ref _arr[index >> 5], prevValue | (_cachedShifts[index & 31]), prevValue) != prevValue);
                }
                else
                {
                    do
                    {
                        prevValue = Interlocked.CompareExchange(ref _arr[index >> 5], 0, 0);
                    }
                    while (Interlocked.CompareExchange(ref _arr[index >> 5], prevValue & ~(_cachedShifts[index & 31]), prevValue) != prevValue);
                }
            }
        }
    }
