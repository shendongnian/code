        public static string NewVer(string oldVer)
        {
            string newVer = oldVer.Trim();
            if (string.IsNullOrEmpty(newVer)) return oldVer;
            if (newVer.Length > 3) return oldVer; 
            // ToCharArray on a small string is going to be faster than regex 
            // and need the Char array for bulding the reaponse
            Char[] chars = newVer.ToCharArray();
            if (!char.IsDigit(chars[chars.Length - 1])) return oldVer;
            byte lastDigit = byte.Parse(chars[chars.Length - 1].ToString());
            if (newVer.Length == 3 && lastDigit == 9) return oldVer;
            lastDigit++;
            newVer = string.Empty;
            for (byte i = 0; i < chars.Length-1; i++)
            {
                newVer += chars[i];
            }
            newVer += lastDigit.ToString();
            return newVer;
        }
