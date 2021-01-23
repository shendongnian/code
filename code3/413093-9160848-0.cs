        static byte[] Hex2Bytes(string hex) {
            if (hex.Length % 2 != 0) throw new ArgumentException();
            var retval = new byte[hex.Length / 2];
            for (int ix = 0; ix < hex.Length; ix += 2) {
                retval[ix / 2] = byte.Parse(hex.Substring(ix, 2), System.Globalization.NumberStyles.HexNumber);                
            }
            return retval;
        }
