    class Program
        {
            static void Main(string[] args)
            {
                var inString = LireFichier(@"C:\temp\file.txt");
                Console.WriteLine(ParseString(inString));
                Console.ReadKey();
            }
    
            public static string LireFichier(string FilePath) //Read the file, send back a string with the text
            {
                using (StreamReader streamReader = new StreamReader(FilePath))
                {
                    string text = streamReader.ReadToEnd();
                    streamReader.Close();
                    return text;
                }
            }
    
            public static string ParseString(string input)
            {
                input = input.Replace(Environment.NewLine,string.Empty);
                input = input.Replace(" ", string.Empty);
                string[] chunks = input.Split(',');
                StringBuilder sb = new StringBuilder();
                foreach (string s in chunks)
                {
                    sb.Append(s);
                    sb.Append(";");
                }
                return sb.ToString(0, sb.ToString().Length - 1);
            }
        }
