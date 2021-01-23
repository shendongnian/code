    public interface ICsvReaderWriter
    {
        List<string[]> Read(string filePath, char delimiter);
        void Write(string filePath, List<string[]> lines, char delimiter);
    }
     
    public class CsvReaderWriter : ICsvReaderWriter
    {
        public List<string[]> Read(string filePath, char delimiter)
        {
            var fileContent = new List<string[]>();
            using (var reader = new StreamReader(filePath, Encoding.Unicode))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        fileContent.Add(line.Split(delimiter));
                    }
                }
            }
            return fileContent;
        }
     
        public void Write(string filePath, List<string[]> lines, char delimiter)
        {
            using (var writer = new StreamWriter(filePath, true, Encoding.Unicode))
            {
                foreach (var line in lines)
                {
                    var data = line.Aggregate(string.Empty,
                                             (current, column) => current +
                                              string.Format("{0}{1}", column,delimiter))
                        .TrimEnd(delimiter);
                    writer.WriteLine(data);
                }
            }
        }
    }
