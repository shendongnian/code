        static void RPGWrite(string write)
        {
            int i = 0;
            StringBuilder sb = new StringBuilder();
            while (i < write.Length)
            {
                string part = write.Substring(i, i + 139);
                int lastSpace = part.LastIndexOf(' ');
                sb.Append(write.Substring(i, i + lastSpace) + System.Environment.NewLine;
                i += lastSpace;
            }
            Console.Write(sb.ToString());
        }
