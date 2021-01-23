        static void Main(string[] args)
        {
            String str = "ThisIsAnInputString";
            String str2 = "This_Is_An_Input_String";
            Console.WriteLine(str);
            Console.WriteLine(str2);
            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            str.ToCharArray().ToList().ForEach(c => sb.Append(c == '_' ? " " :  char.IsLower(c) ? c.ToString() : " " + c.ToString()));
            str2.ToCharArray().ToList().ForEach(c => sb2.Append(c == '_' ? " " : char.IsLower(c) ? c.ToString() : " " + c.ToString()));
            str = sb.ToString().Trim(" ".ToCharArray());
            str2 = sb2.ToString().Trim(" ".ToCharArray());
            Console.WriteLine(str);
            Console.WriteLine(str2);
            Console.Read();
        }
