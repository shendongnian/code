    public static string Reverse(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    
        public static string Encrypt(string source)
        {
            string prefix = Guid.NewGuid().ToString();
            string infix = Guid.NewGuid().ToString();
            string postfix = Guid.NewGuid().ToString();
    
            int length = source.Length;
            string firstHalf = source.Substring(0, length / 2);
            string secondHalf = source.Substring(length / 2);
    
            string ConcatedPassword = prefix + firstHalf + infix + secondHalf + postfix;
    
            string enCrypted = "";
            try
            {
                ConcatedPassword = Reverse(ConcatedPassword);
                Dictionary<char, char> sourceTable = AddDictionaryItems();
    
                char[] sourceArray = ConcatedPassword.ToCharArray();
                StringBuilder encryptedData = new StringBuilder();
                foreach (char chr in sourceArray)
                {
                    KeyValuePair<char, char> Pair;
                    Pair = sourceTable.First(tuple => tuple.Key == chr);
                    encryptedData.Append(Pair.Value);
                }
                enCrypted = encryptedData.ToString();
            }
            catch (Exception ex)
            {
    
            }
            return enCrypted;
        }
    
        public static string Decrypt(string source)
        {
            string deCrypted = "";
            try
            {
                source = Reverse(source);
                Dictionary<char, char> sourceTable = AddDictionaryItems();
    
                char[] sourceArray = source.ToCharArray();
                StringBuilder decryptedData = new StringBuilder();
                foreach (char chr in sourceArray)
                {
                    KeyValuePair<char, char> Pair;
                    Pair = sourceTable.First(tuple => tuple.Value == chr);
                    decryptedData.Append(Pair.Key);
                }
                deCrypted = decryptedData.ToString();
                string prefixRemoved = deCrypted.Remove(0, 36);
                string postfixRemoved = prefixRemoved.Remove(prefixRemoved.Length - 36);
                string infixRemoved = postfixRemoved.Remove((postfixRemoved.Length - 36) / 2, 36);
                deCrypted = infixRemoved;
            }
            catch (Exception ex)
            {
    
            }
            return deCrypted;
        }
    
        public static Dictionary<char, char> AddDictionaryItems()
        {
            Dictionary<char, char> dc = new Dictionary<char, char>();
            try
            {
                int initial = 33;
                int jump = 10;
                int final = 127 - jump;
    
                for (int ascii = initial; ascii < final; ascii++)
                {
                    dc.Add((char)ascii, (char)(ascii + jump));
                }
                for (int ascii = final; ascii < final + jump; ascii++)
                {
                    dc.Add((char)ascii, (char)(initial));
                    initial++;
                }
            }
            catch (Exception ex)
            {
    
            }
            return dc;
        }
    protected void Page_Load(object sender, EventArgs e)
    {
         string password = "$Om3P@55w0r6";
         string encrypted = Encrypt(password);
         string decrypted = Decrypt(encrypted);
    }
