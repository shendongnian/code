     internal class Percent
        {
            private readonly decimal _value;
            public decimal Value
            {
                get { return _value; }
            }
            public Percent(decimal value)
            {
                _value = (100 * value);
                if (value < 0m || value > 1m)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
            }
            public override string ToString()
            {
                return String.Format("{0}%", _value);
            }
            public override int GetHashCode()
            {
                // HashCode implementation;
            }
            public override bool Equals(object obj)
            {
                // Equals implementation;
            }
        }
