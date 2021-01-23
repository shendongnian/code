    public void PopulateData()
        {
            this.SuspendLayout();
            DataGridViewRow[] rows = new DataGridViewRow[Data.RowCount];
            for (int i = 0; i < rows.Length; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Height = Data.RowHeights[i];
                rows[i] = row;
            }
            this.Rows.AddRange(rows);
            this.ResumeLayout();
        }
