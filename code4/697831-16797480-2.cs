    public partial class Form1 : Form
    {
        private CsvDataSource _data;
        private ObservableCollection<CsvDataRow> _rows;
        public Form1()
        {
            InitializeComponent();
        }
        public void LoadCsv(CsvDataSource data)
        {
            _data = data;
            _rows = _data.Rows;
            dataGridView1.DataSource = _rows;
        }
        public void SaveCsv(string path)
        {
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(string.Join(_data.Delimiter.ToString(), _data.Columns));
                foreach (var row in _rows)
                {
                    writer.WriteLine(row.ToCsvString());
                }
            }
        }
    }
