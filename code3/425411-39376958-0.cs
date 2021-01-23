    class LongLivedObject
    {
        private Dictionary <string, string> _settings;
        public LongLivedObject(Dictionary <string, string> settings)
        {   // In C# this always duplicates the data structure and takes O(n) time.
            // C++ will automatically try to decide if it could do a swap instead.
            // C++ always lets you explicitly say you want to do the swap.
            _settings = new Dictionary <string, string>(settings);
        }
    }
