    public class Program
    {
        static void Main()
        {
            var values = new[] 
            { 
                "12325 NHGKF", 
                "34523 KGJ", 
                "29302 MMKSEIE", 
                "49504EFDF" 
            };
            foreach (var value in values)
            {
                var tokens = Regex.Split(value, @"(\d{5})\s*(\w+)");
                Console.WriteLine("key: {0}, value: {1}", tokens[1], tokens[2]);
            }
        }
    }
