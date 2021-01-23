        public Form1()
        {
            InitializeComponent();
            var dto = GroupedDtoWorker.GetIt();
            dataGridView.Columns.Add("units", "units");
            foreach (GroupedDto groupedDto in dto)
            {
                foreach (KeyValuePair<string, string> keyValuePair in groupedDto.DateMessage)
                {
                    dataGridView.Columns.Add(keyValuePair.Key, keyValuePair.Key);
                }
            }
            dataGridView.Columns.Add("count", "count");
            foreach (GroupedDto groupedDto in dto)
            {
                String[] row = new string[dataGridView.Columns.Count];
                row[0] = groupedDto.Unit.ToString();
                row[dataGridView.Columns.Count - 1] = groupedDto.Count.ToString();
                foreach (KeyValuePair<string, string> keyValuePair in groupedDto.DateMessage)
                {
                    Int32 index = dataGridView.Columns[keyValuePair.Key].Index;
                    row[index] = keyValuePair.Value;
                }
                dataGridView.Rows.Add(row);
            }
        }
