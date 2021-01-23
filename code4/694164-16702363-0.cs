        static void Main(string[] args)
        {
            string string1 = "hello";
            string string2 = "bye";
            string[] lines =
                {
                    string1 + 
                    Environment.NewLine + 
                    string2
                };
            System.IO.File.AppendAllLines(@"c:\output.csv", lines);
        }
