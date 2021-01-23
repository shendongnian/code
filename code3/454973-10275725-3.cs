    class Program
    {
        static void Main(string[] args)
        {
            // second argument is a lambda that describes how to convert the line into the type you require
            var dateList = FileToGenericList<DateTime>("dates.txt", DateTime.Parse);
            var stringList = FileToGenericList<string>("strings.txt", s => s);
            var intList = FileToGenericList<int>("integers.txt", Int32.Parse); 
            // example with a fictional arbitrary type for which a conversion function exists
            // var anotherList = FileToGenericList<AnotherType>("another.txt", s => AnotherType.MyConvertFunction(s, secondParam, etc)); 
           
            Console.ReadLine();
        }
        static List<T> FileToGenericList<T>(string filePath, Func<string, T> parseFunc, int ignoreFirstXLines = 0, bool stripQuotes = true)
        {
            var output = new List<T>();
            try
            {
                using (StreamReader stream = new StreamReader(File.Open(filePath, FileMode.Open)))
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
