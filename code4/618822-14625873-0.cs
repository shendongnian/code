    class Program
    {
        static void Main(string[] args)
        {
            //(?>\<).*(?>\>)
            string s=System.IO.File.ReadAllText("file.xml");
            var matches = Regex.Matches(s, @"(?>\<).*(?>\>)");
            var sBuilder=new StringBuilder();
            foreach (Match item in matches)
            {
                sBuilder.Append(item.Value);
            }
            Console.WriteLine(sBuilder.ToString());
        }
    }
