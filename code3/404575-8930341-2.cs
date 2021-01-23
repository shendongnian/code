        public class SignType
        {
            private static Dictionary<string, int> Values = new Dictionary<string, int>();
            public SignType()
            {
                Values.Add("-", 0);
                Values.Add("+", 1);
            }
            public int this[string s]
            {
                get { return Values[s]; }
            }
        }
    }
