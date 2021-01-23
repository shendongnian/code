        [Flags]
        public enum Symbol
        {
            A,
            B,
        }
        public enum Production
        {
            AA = Symbol.A *10 + Symbol.A, //0
            AB = Symbol.A *10 + Symbol.B, //1
            BA = Symbol.B *10 + Symbol.A, //10
        }
