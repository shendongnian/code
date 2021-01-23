        static void Main(string[] args)
        {
            String details = "XSD34AB67";
            string numeric = "";
            string nonnumeric = "";
            char[] mychar = details.ToCharArray();
            foreach (char ch in mychar)
            {
                if (char.IsDigit(ch))
                {
                    numeric = numeric + ch.ToString();
                }
                else
                {
                    nonnumeric = nonnumeric + ch.ToString();
                }
            }
            int i = Convert.ToInt32(numeric);
            Console.WriteLine(numeric);
            Console.WriteLine(nonnumeric);
            Console.ReadLine();
        }
    }
}
