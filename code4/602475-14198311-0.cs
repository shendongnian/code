    public class CsvParser
    {
        private readonly List<List<string>> entries = new List<List<string>>();
        private string currentEntry = "";
        private bool insideQuotation;
        /// <summary>
        ///   Returns all scanned entries.
        ///   Outer IEnumerable = rows,
        ///   inner IEnumerable = columns of the corresponding row.
        /// </summary>
        public IEnumerable<IEnumerable<string>> Entries
        {
            get { return entries; }
        }
        public void ScanNextLine(string line)
        {
            // At the beginning of the line
            if (!insideQuotation)
            {
                entries.Add(new List<string>());
            }
            // The characters of the line
            foreach (char c in line)
            {
                if (insideQuotation)
                {
                    if (c == '"')
                    {
                        insideQuotation = false;
                    }
                    else
                    {
                        currentEntry += c;
                    }
                }
                else if (c == ',')
                {
                    entries[entries.Count - 1].Add(currentEntry);
                    currentEntry = "";
                }
                else if (c == '"')
                {
                    insideQuotation = true;
                }
                else
                {
                    currentEntry += c;
                }
            }
            // At the end of the line
            if (!insideQuotation)
            {
                entries[entries.Count - 1].Add(currentEntry);
                currentEntry = "";
            }
            else
            {
                currentEntry += "\n";
            }
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory + @"blogpost";
            string[] allLines = File.ReadAllLines(dir + "csvdatabase.csv");
            CsvParser parser = new CsvParser();
            foreach (string line in lines)
            {
                parser.ScanNextLine(line);
            }
        }
    }
