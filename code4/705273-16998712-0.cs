        static byte[] ToArrayOfByteValues(this string str)
        {
            var charArray = str.ToArray();
            var byteArray = new byte[charArray.Length / 2];
            for (int i = 0; i < byteArray.Length; i++)
            {
                var q = new StringBuilder().Append(charArray.Skip(i * 2).Take(2).ToArray<char>()).ToString();
                byteArray[i] = Byte.Parse(q, System.Globalization.NumberStyles.HexNumber);
            }
            return byteArray;
        }
