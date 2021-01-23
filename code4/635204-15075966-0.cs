    class Program
    {
        private const string csv ="Header\r\nLine1\r\nLine2";
        static void Main(string[] args)
        {
            StringReader reader = new StringReader(csv);
            StringBuilder builder = new StringBuilder();
            bool header = true;
            while (true)
            {
                string line = reader.ReadLine();
                if(header)
                {
                    header = false;
                    continue;
                }
                if (line == null)
                    break;
                builder.AppendLine(line);
                
            }
            Console.WriteLine(builder.ToString());
            Console.ReadLine();
        }
    }
