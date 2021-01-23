    public class Table
    {
        private Dictionary<string, double> _regionTimeValues = new Dictionary<string, double>();
        private String _region;
        public Table(String region)
        {
            _region = region;
        }
        public void AddValue(string key, double value)
        {
            _regionTimeValues.Add(key, value);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Table> tables = new Dictionary<string, Table>();
            using (var reader = new StreamReader("Data.csv"))
            {
                // First line contains column names.
                var columnNames = reader.ReadLine().Split(',');
                for(int i = 1; i < columnNames.Length; ++i)
                {
                    var columnName = columnNames[i];
                    tables.Add(columnName, new Table(columnName));
                }
                var line = reader.ReadLine();
                while (line != null)
                {
                    var columns = line.Split(',');
                    for (int i = 1; i < columns.Length; ++i)
                    {
                        var table = tables[columnNames[i]];
                        table.AddValue(columns[0], double.Parse(columns[i]));
                    }
                    line = reader.ReadLine();
                }
            }
        }
    }
