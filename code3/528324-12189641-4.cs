    class Program
    {
        internal static ILog logger = LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            string firstName, lastName, dob, lexisNexisID;
            string filePath = @"yor directory path\your file name";
            
            ExcelProvider provider = ExcelProvider.Create(filePath, "Sheet1");
            foreach (ExcelRow row in (from x in provider select x))
            {
                Console.WriteLine("{0}", row.GetString(1));
                /* the row.Getstring(index) the index is for your column you mey select morcolume as Console.WriteLine("{0}/t{1}", row.GetString(0),row.Getstring(1)); */
            }
        }
    }
    public class ExcelRow
    {
        List<object> columns;
        public ExcelRow()
        {
            columns = new List<object>();
        }
        internal void AddColumn(object value)
        {
            columns.Add(value);
        }
        public object this[int index]
        {
            get { return columns[index]; }
        }
        public string GetString(int index)
        {
            if (columns[index] is DBNull)
            {
                return null;
            }
            return columns[index].ToString();
        }
        public int Count
        {
            get { return this.columns.Count; }
        }
    }
    public class ExcelProvider : IEnumerable<ExcelRow>
    {
        private string sheet;
        private string filePath;
        private List<ExcelRow> rows;
        public ExcelProvider()
        {
            rows = new List<ExcelRow>();
        }
        public static ExcelProvider Create(string filePath, string sheet)
        {
            ExcelProvider provider = new ExcelProvider();
            provider.sheet = sheet;
            provider.filePath = filePath;
            return provider;
        }
        private void Load()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=    ""Excel 12.0;HDR=YES;""";
            connectionString = string.Format(connectionString, filePath);
            rows.Clear();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                }
                using (OleDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from [" + sheet + "$]";
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ExcelRow newRow = new ExcelRow();
                            for (int count = 0; count < reader.FieldCount; count++)
                            {
                                newRow.AddColumn(reader[count]);
                            }
                            rows.Add(newRow);
                        }
                    }
                }
            }
        }
        public IEnumerator<ExcelRow> GetEnumerator()
        {
            Load();
            return rows.GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            Load();
            return rows.GetEnumerator();
        }
    }
