    class Program
    {
        static void Main(string[] args)
        {
            // second argument is a lambda that describes how to convert the line into the type you require
            var dateList = FileToGenericList<DateTime>("dates.txt", s => DateTime.Parse(s));
            var stringList = FileToGenericList<string>("strings.txt", s => s);
            var intList = FileToGenericList<int>("integers.txt", s => Int32.Parse(s));            Console.ReadLine();
        }
        static List<T> FileToGenericList<T>(string FilePath, Func<string, T> parseFunc, int ignoreFirstXLines = 0, bool stripQuotes = true)
        {
            var output = new List<T>();
            try
            {
                using (StreamReader stream = new StreamReader(File.Open(FilePath, FileMode.Open)))
                {
                    string line;
                    int currentLine = 0;
                    while ((line = stream.ReadLine()) != null)
                    {
                        // Skip first x lines
                        if (currentLine < ignoreFirstXLines)
                            continue;
                        // Remove quotes if needed
                        if (stripQuotes == true)
                            line = line.Replace(@"""", @"");
                        var parsedValue = parseFunc(line);
                        output.Add(parsedValue);
                        currentLine++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error - there was a problem reading the file at " + FilePath + ".  Error details: " + ex.Message);
            }    
            return output;
       }
    }
