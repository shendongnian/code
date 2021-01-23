        static void RPGWrite(string write)
        {
            int i = 0;
            StringBuilder sb = new StringBuilder();
            while (i < write.Length)
            {
                if(i + 139 < write.Length)
                { 
                    string part = write.Substring(i, i + 139);
                    int lastSpace = part.LastIndexOf(' ');
                    sb.Append(write.Substring(i, i + lastSpace) + System.Environment.NewLine;
                    i += lastSpace;
                }
                else
                {
                    sb.Append(write.Substring(i));
                    break;
                }
            }
            Console.Write(sb.ToString());
        }
