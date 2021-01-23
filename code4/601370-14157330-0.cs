    public partial class FormDemo : Form
    {
        private List<Element> _Elements;
        public FormDemo()
        {
            InitializeComponent();
            _Elements = new List<Element>();
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = true;
            dataGridView.VirtualMode = true;
            dataGridView.CellValueNeeded += OnDataGridViewCellValueNeeded;
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += OnBackgroundWorkerDoWork;
            backgroundWorker.ProgressChanged += OnBackgroundWorkerProgressChanged;
            backgroundWorker.RunWorkerCompleted += OnBackgroundWorkerRunWorkerCompleted;
        }
        private void OnBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            var filename = (string)e.Argument;
            using (var reader = new StreamReader(filename))
            {
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 2)
                    {
                        var element = new Element() { Number = parts[0], Available = parts[1] };
                        _Elements.Add(element);
                    }
                    if (_Elements.Count % 100 == 0)
                    {
                        backgroundWorker.ReportProgress(0);
                    }
                }
            }
        }
        private void OnBackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            dataGridView.RowCount = _Elements.Count;
        }
        private void OnBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView.RowCount = _Elements.Count;
            button.Enabled = true;
        }
        private void OnButtonLoadClick(object sender, System.EventArgs e)
        {
            if (!backgroundWorker.IsBusy
                && DialogResult.OK == openFileDialog.ShowDialog())
            {
                button.Enabled = false;
                backgroundWorker.RunWorkerAsync(openFileDialog.FileName);
            }
        }
        private void OnDataGridViewCellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            var element = _Elements[e.RowIndex];
            switch (e.ColumnIndex)
            {
                case 0:
                    e.Value = element.Number;
                    break;
                case 1:
                    e.Value = element.Available;
                    break;
            }
        }
        private class Element
        {
            public string Available { get; set; }
            public string Number { get; set; }
        }
    }
