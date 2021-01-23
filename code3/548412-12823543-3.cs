        public class ThreeNibbleNumber
        {
            private _value;
            public ushort Value
            {
                get
                {
                    return _value;
                }
                set
                {
                    if (value > 4095)
                    {
                        throw new ArgumentException("The number is too large.");
                    }
                    else
                    {
                        _value = value;
                    }
                }
            }
            public override string ToString()
            {
                return Value.ToString("x");
            }
        }
