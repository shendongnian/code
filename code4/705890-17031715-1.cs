        private static byte[] GetDataFromHex(string hex)
        {
            var bytes = new List<byte>();
            for (int i = 0; i < hex.Length; i += 2)
            {
                bytes.Add((byte)int.Parse(hex.Substring(i, 2), System.Globalization.NumberStyles.HexNumber));
            }
            return bytes.ToArray();
        }
