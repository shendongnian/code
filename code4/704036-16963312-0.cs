        // StringBuilder inserting at 0 index
        public static string Reverse2(string inputString)
        {
            var result = new StringBuilder();
            foreach (char ch in inputString)
            {
                result.Insert(0, ch);
            }
            return result.ToString();
        }
        // Process inputString backwards and append with StringBuilder
        public static string Reverse3(string inputString)
        {
            var result = new StringBuilder();
            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                result.Append(inputString[i]);
            }
            return result.ToString();
        }
        // Convert string to array and swap pertinent items
        public static string Reverse4(string inputString)
        {
            var chars = inputString.ToCharArray();
            for (int i = 0; i < (chars.Length/2); i++)
            {
                var temp = chars[i];
                chars[i] = chars[chars.Length - 1 - i];
                chars[chars.Length - 1 - i] = temp;
            }
            return new string(chars);
        }
