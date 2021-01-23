    using System.IO;
    using System.Linq;
    
    class Test
    {
        static void Main()
        {
            var lines = ReadLines("test.txt");
            var query = from x in lines
                        from y in lines
                        select x + "/" + y;
            foreach (var line in query)
            {
                Console.WriteLine(line);
            }
        }
        
        static IEnumerable<string> ReadLines(string file)
        {
            using (var reader = File.OpenText(file))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
