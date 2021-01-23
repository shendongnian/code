     public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            //dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = "CELL123456789012345679801234567890";
                row.Cells[1].Value = "CELL 1";
                row.Cells[2].Value = "CELL 2";
                row.Cells[3].Value = "CELL 3";
                row.Cells[4].Value = "CELL 4";
                row.Cells[5].Value = "CELL 5";
            }
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.Value == null)
                return;
            var s = e.Graphics.MeasureString(e.Value.ToString(), dataGridView1.Font);
            if (s.Width > dataGridView1.Columns[e.ColumnIndex].Width)
            {
                using (
          Brush gridBrush = new SolidBrush(this.dataGridView1.GridColor),
          backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                {
                    e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                    e.Graphics.DrawString(e.Value.ToString(), dataGridView1.Font, Brushes.Black, e.CellBounds, StringFormat.GenericDefault);
                    dataGridView1.Rows[e.RowIndex].Height = (int)(s.Height * Math.Ceiling(s.Width / dataGridView1.Columns[e.ColumnIndex].Width));
                    e.Handled = true;
                }
            }
        }
