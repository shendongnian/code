    public class CsvDataSource
    {
        public char Delimiter { get; private set; }
        public CsvDataSource()
            : this(',')
        { }
        public string[] Columns { get; private set; }
        public ObservableCollection<CsvDataRow> Rows { get; private set; }
        public CsvDataSource(char delimiter)
        {
            Delimiter = delimiter;
        }
        public void LoadCsv(string csvFileName)
        {
            string header;
            string data;
            using (var reader = new StreamReader(csvFileName))
            {
                header = reader.ReadLine(); // assumes 1st row is column headers
                data = reader.ReadToEnd();
            }
            Columns = header.Split(Delimiter);
            var rows = Regex.Split(data, Environment.NewLine);
            if (!rows.Select(row => row.Split(Delimiter)).All(row => row.Length == Columns.Length)) throw new FormatException("Inconsistent data format.");
            Rows = new ObservableCollection<CsvDataRow>(rows.Select(row => CsvDataRow.Create(row, Delimiter)));
        }
    }
