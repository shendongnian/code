    public partial class Form1 : Form
    {
        private BackgroundWorker _worker;
        public Form1()
        {
            InitializeComponent();
            _worker = new BackgroundWorker();
            _worker.DoWork += _worker_DoWork;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
        }
        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = GetAutoSizeColumnsWidth(dataGridView1);
        }
        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetAutoSizeColumnsWidth(dataGridView1, (int[])e.Result);
        }
        private int[] GetAutoSizeColumnsWidth(DataGridView grid)
        {
            var src = ((IEnumerable)grid.DataSource)
                .Cast<object>()
                .Select(x => x.GetType()
                    .GetProperties()
                    .Select(p => p.GetValue(x, null)?.ToString() ?? string.Empty)
                    .ToArray()
                );
            int[] widths = new int[grid.Columns.Count];
            // Iterate through the columns.
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                // Leverage Linq enumerator to rapidly collect all the rows into a string array, making sure to exclude null values.
                string[] colStringCollection = src.Where(r => r[i] != null).Select(r => r[i].ToString()).ToArray();
                // Sort the string array by string lengths.
                colStringCollection = colStringCollection.OrderBy((x) => x.Length).ToArray();
                // Get the last and longest string in the array.
                string longestColString = colStringCollection.Last();
                // Use the graphics object to measure the string size.
                var colWidth = TextRenderer.MeasureText(longestColString, grid.Font);
                // If the calculated width is larger than the column header width, set the new column width.
                if (colWidth.Width > grid.Columns[i].HeaderCell.Size.Width)
                {
                    widths[i] = (int)colWidth.Width;
                }
                else // Otherwise, set the column width to the header width.
                {
                    widths[i] = grid.Columns[i].HeaderCell.Size.Width;
                }
            }
            return widths;
        }
        public void SetAutoSizeColumnsWidth(DataGridView grid, int[] widths)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                grid.Columns[i].Width = widths[i];
            }
        }
    }
