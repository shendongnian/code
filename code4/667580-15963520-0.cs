        static void Main(string[] args)
        {
            string s = "\u00C0";
            Console.WriteLine(s);
            byte[] bytes = ASCIIEncoding.ASCII.GetBytes(s);
            Console.WriteLine(BitConverter.ToString(bytes));
            Console.WriteLine(ASCIIEncoding.ASCII.GetString(bytes));
            Console.WriteLine("Again");
            bytes = Encoding.UTF8.GetBytes(s);
            Console.WriteLine(BitConverter.ToString(bytes));
            Console.WriteLine(Encoding.UTF8.GetString(bytes));
            Console.ReadLine();
        }
