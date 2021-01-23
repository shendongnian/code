        static readonly Random r = new Random();
        public static Int32 GetNext(int maxValue)
        {
            return r.Next(maxValue);
        }
        public static Int32 GetNext()
        {
            return r.Next();
        }
    }
