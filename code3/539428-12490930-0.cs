        class CustomAscii
        {
            private static Dictionary<char, byte> dictionary;
            
            static CustomAscii()
            {
                byte numcounter = 0x30;
                byte charcounter = 0x41;
                byte ucharcounter = 0x61;
                string numbers = "0123456789";
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string uchars = "abcdefghijklmnopqrstuvwxyz";
                dictionary = new Dictionary<char, byte>();
                foreach (char c in numbers)
                {
                    dictionary.Add(c, numcounter++);
                }
                foreach (char c in chars)
                {
                    dictionary.Add(c, charcounter++);
                }
                foreach (char c in uchars)
                {
                    dictionary.Add(c, ucharcounter++);
                }
            }
    
            public static byte[] getCustomBytes(string t)
            {
                int iter = 0;
                byte[] b = new byte[t.Length];
                foreach (char c in t)
                {
                    b[iter] = dictionary[c];
                    //DEBUG: Console.WriteLine(b[iter++].ToString());
                }
    
                return b;
            }
        }
