        public static Color HexStringToColor(string hexColor)
        {
            string hc = ExtractHexDigits(hexColor);
            if (hc.Length != 6)
            {
                // you can choose whether to throw an exception
                //throw new ArgumentException("hexColor is not exactly 6 digits.");
                return Color.Empty;
            }
            string r = hc.Substring(0, 2);
            string g = hc.Substring(2, 2);
            string b = hc.Substring(4, 2);
            Color color = Color.Empty;
            try
            {
                int ri = Int32.Parse(r, NumberStyles.HexNumber);
                int gi = Int32.Parse(g, NumberStyles.HexNumber);
                int bi = Int32.Parse(b, NumberStyles.HexNumber);
                color = Color.FromArgb(ri, gi, bi);
            }
            catch
            {
                // you can choose whether to throw an exception
                //throw new ArgumentException("Conversion failed.");
                return Color.Empty;
            }
            return color;
        }
