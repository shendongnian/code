    static class Program
    {
        static void Main(string[] args)
        {
            string Password = "(O*@aJY^+{PC";
            string Account  = "email@Abc.com";
            string Name     = "Ted Nelson";
            if (Password.IsNotSequentialChars(Account, 2) && Password.IsNotSequentialChars(Name, 2))
                Console.WriteLine("Passed");
            else
                Console.WriteLine("Failed");
        }
        public static bool IsNotSequentialChars(this string Src, string Dest, int check_len)
        {
            if (check_len < 1 || Src.Length < check_len) return true;
            Match m = Regex.Match(Src, "(?=(.{" + check_len + "})).");
            bool bOK = m.Success;
     
            while (bOK && m.Success)
            {
                // Edit: remove unnecessary '.*' from regex.
                // And btw, is regex needed at all in this case?
                bOK = !Regex.Match(Dest, "(?i)" + Regex.Escape(m.Groups[1].Value)).Success;
                if (!bOK)
                    Console.WriteLine("Destination contains " + check_len + " sequential source letter(s) '" + m.Groups[1].Value + "'");
                m = m.NextMatch();
            }
            return bOK;
        }
    }
