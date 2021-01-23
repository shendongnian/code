        public struct CssColor
        {
            public CssColor(uint colorValue)
            {
                byte[] colorBytes = BitConverter.GetBytes(colorValue);
                if (BitConverter.IsLittleEndian)
                {
                    if (colorBytes[3] > 0)
                    {
                        throw new ArgumentException("The value is outside the range for a CSS Color.", "s");
                    }
                    R = colorBytes[2];
                    G = colorBytes[1];
                    B = colorBytes[0];
                }
                else
                {
                    if (colorBytes[0] > 0)
                    {
                        throw new ArgumentException("The value is outside the range for a CSS Color.", "s");
                    }
                    R = colorBytes[1];
                    G = colorBytes[2];
                    B = colorBytes[3];
                }
            }
            public byte R;
            public byte G;
            public byte B;
            public override string ToString()
            {
                return string.Format("#{0:x}{1:x}{2:x}", R, G, B).ToUpperInvariant();
            }
            public static CssColor Parse(string s)
            {
                if (s == null)
                {
                    throw new ArgumentNullException("s");
                }
                s = s.Trim();
                if (!s.StartsWith("#") || s.Length > 7)
                {
                    throw new FormatException("The input is not a valid CSS color string.");
                }
                s = s.Substring(1, s.Length - 1);
                uint color = uint.Parse(s, System.Globalization.NumberStyles.HexNumber);
                return new CssColor(color);
            }
        }
