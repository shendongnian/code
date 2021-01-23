        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Image");
            dataTable.Rows.Add("Desert", @"C:\Users\Public\Pictures\Sample Pictures\Desert.jpg");
            dataTable.Rows.Add("Tulips", @"C:\Users\Public\Pictures\Sample Pictures\Tulips.jpg");
            dataTable.AcceptChanges();
            DataGridViewTextBoxColumn textColumn = new DataGridViewTextBoxColumn();
            textColumn.DataPropertyName = "Name";
            textColumn.HeaderText = "Name";
            textColumn.Width = 100;
            dataGridView1.Columns.Add(textColumn);
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.DataPropertyName = "Image";
            imageColumn.HeaderText = "Image";
            imageColumn.Width = 100;            
            dataGridView1.Columns.Add(imageColumn);
            dataGridView1.DataSource = dataTable;
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex] is DataGridViewImageColumn)
            {
                string imagePath = (e.Value ?? "").ToString().Trim();
                if(System.IO.File.Exists(imagePath))
                    e.Value = Image.FromFile(imagePath);
            }
        }
