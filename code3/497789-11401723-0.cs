    class MDRResult : DataGrid
    {
        public MDRResult(string[] headers, string[][] fields)
            : base()
        {
            for (int i = 0; i < headers.Length; ++i)
                this.Columns.Add(new DataGridTextColumn()
                {
                    Header = headers[i],
                    Binding = new Binding("[" + i + "]")
                });
            this.AutoGenerateColumns = false;
            this.ItemsSource = fields;
        }
    }
