        static void Main(string[] args)
        {
            string a = "hello";
            byte[] b = UnicodeEncoding.Unicode.GetBytes(a);
            string c = ASCIIEncoding.ASCII.GetString(b);
            Console.WriteLine(a == c);
        }
