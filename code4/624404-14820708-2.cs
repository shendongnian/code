        public static byte[] ToBinary(string imageDataHex)
        {
            //this function taken entirely from:
            // http://www.codeproject.com/Articles/27431/Writing-Your-Own-RTF-Converter
            if (imageDataHex == null)
            {
                throw new ArgumentNullException("imageDataHex");
            }
            int hexDigits = imageDataHex.Length;
            int dataSize = hexDigits / 2;
            byte[] imageDataBinary = new byte[dataSize];
            StringBuilder hex = new StringBuilder(2);
            int dataPos = 0;
            for (int i = 0; i < hexDigits; i++)
            {
                char c = imageDataHex[i];
                if (char.IsWhiteSpace(c))
                {
                    continue;
                }
                hex.Append(imageDataHex[i]);
                if (hex.Length == 2)
                {
                    imageDataBinary[dataPos] = byte.Parse(hex.ToString(), System.Globalization.NumberStyles.HexNumber);
                    dataPos++;
                    hex.Remove(0, 2);
                }
            }
            return imageDataBinary;
        }
