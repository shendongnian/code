    static void Main(string[] args)
        {
            System.Diagnostics.Debug.WriteLine(NewVer("H"));
            System.Diagnostics.Debug.WriteLine(NewVer("Hi"));
            System.Diagnostics.Debug.WriteLine(NewVer("Hii"));
            System.Diagnostics.Debug.WriteLine(NewVer("Hiii"));
            System.Diagnostics.Debug.WriteLine(NewVer("H1"));
            System.Diagnostics.Debug.WriteLine(NewVer("H9"));
            System.Diagnostics.Debug.WriteLine(NewVer("Hi1"));
            System.Diagnostics.Debug.WriteLine(NewVer("H19"));
            System.Diagnostics.Debug.WriteLine(NewVer("9"));
            System.Diagnostics.Debug.WriteLine(NewVer("09"));
            System.Diagnostics.Debug.WriteLine(NewVer("009"));
            System.Diagnostics.Debug.WriteLine(NewVer("7"));
            System.Diagnostics.Debug.WriteLine(NewVer("07"));
            System.Diagnostics.Debug.WriteLine(NewVer("27"));
            System.Diagnostics.Debug.WriteLine(NewVer("347"));
            System.Diagnostics.Debug.WriteLine(NewVer("19"));
            System.Diagnostics.Debug.WriteLine(NewVer("999"));
            System.Diagnostics.Debug.WriteLine(NewVer("998"));
            System.Diagnostics.Debug.WriteLine(NewVer("C99"));
            System.Diagnostics.Debug.WriteLine(NewVer("C08"));
            System.Diagnostics.Debug.WriteLine(NewVer("C09"));
            System.Diagnostics.Debug.WriteLine(NewVer("C11"));
        }
        public static string NewVer(string oldVer)
        {
            string newVer = oldVer.Trim();
            if (string.IsNullOrEmpty(newVer)) return oldVer;
            if (newVer.Length > 3) return oldVer;
            // at this point all code paths need char by postion
            // regex is not the appropriate tool
            Char[] chars = newVer.ToCharArray();
            if (!char.IsDigit(chars[chars.Length - 1])) return oldVer;
            byte lastDigit = byte.Parse(chars[chars.Length - 1].ToString());
            if (lastDigit != 9)
            {
                lastDigit++;
                StringBuilder sb = new StringBuilder();
                for (byte i = 0; i < chars.Length - 1; i++)
                {
                    sb.Append(chars[i]);
                }
                sb.Append(lastDigit.ToString());
                return sb.ToString();
            }
            // at this point the last char is 9  and lot of edge cases 
            if (chars.Length == 1) return (lastDigit + 1).ToString();
            if (char.IsDigit(chars[chars.Length - 2]))
            {
                if (chars.Length == 2) return ((byte.Parse(newVer)) + 1).ToString();
                byte nextToLastDigit = byte.Parse(chars[chars.Length - 2].ToString());
                if (nextToLastDigit == 9)
                {
                    if (char.IsDigit(chars[0]))
                    {
                        byte firstOfthree = byte.Parse(chars[0].ToString());
                        if (firstOfthree == 9) return oldVer; // edge case 999
                        // all three digtis and not 999
                        return ((byte.Parse(newVer)) + 1).ToString();
                    }
                    // have c99
                    return oldVer;
                }
                else
                {
                    //have c 1-8 9 
                    return chars[0].ToString() + (10 * nextToLastDigit + lastDigit + 1).ToString();        
                }
            }
            // at this point have c9 or cc9
            if (chars.Length == 3) return oldVer;
            // at this point have c9
            return chars[0].ToString() + "10";
        }
