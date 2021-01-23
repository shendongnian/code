    using ChoETL;
    using System.IO;
    public class FromCSVtoJSON
    {
        public FromCSVtoJSON()
        {
        }
        public void convertFile(string inputFile, string outputFile)
        {
            using (var writer = new StreamWriter(outputFile))
            {
                int row = 0;
                writer.Write("[\r\n");
                foreach (var e in new ChoCSVReader(inputFile).WithHeaderLineAt())
                {
                    writer.Write((row > 0 ? ",\r\n" : "") + e.DumpAsJson());
                    writer.Flush();
                    row++;
                }
                writer.Write("]");
                writer.Flush();
                writer.Close();
            }
        }
    }
