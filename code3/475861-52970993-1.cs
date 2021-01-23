    using ChoETL;
    using System.IO;
    public class FromCSVtoJSON
    {
        public FromCSVtoJSON()
        {
        }
        public void convertFile(string inputFile, string outputFile)
        {
            using (var writer = new ChoJSONWriter(outputFile))
            {
                using (var reader = new ChoCSVReader(inputFile).WithFirstLineHeader())
                {
                    writer.Write(reader);
                }
            }
        }
    }
