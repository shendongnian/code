    class Program
    {
        static void Main(string[] args)
        {
            // Open and read into a string the file containing the XML
            string s = System.IO.File.ReadAllText("file.xml");
            // You have too match (?>\<).*(?>\>), which also removes the line feeds
            var matches = Regex.Matches(s, @"(?>\<).*(?>\>)");
            // Use a StringBuilder to append the matches
            var sBuilder = new StringBuilder();
            // Loop through the matches
            foreach (Match item in matches)
            {
                sBuilder.Append(item.Value);
            }
            // Show the result
            Console.WriteLine(sBuilder.ToString());
        }
    }
