    class Program
    {
        static void Main(string[] args)
        {
            XElement main = XElement.Load(@"users.xml");
    
            var results = main.Descendants("User")
                .Descendants("Name")
                .Where(e => e.Value == "John Doe")
                .Select(e => e.Parent)
                .Descendants("test")
                .Select(e => new { date = e.Descendants("Date").FirstOrDefault().Value, points = e.Descendants("points").FirstOrDefault().Value });
    
            foreach (var result in results)
                Console.WriteLine("{0}, {1}", result.date, result.points);
            Console.ReadLine();
        }
    }
