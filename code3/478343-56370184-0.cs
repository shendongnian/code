    DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cellStyle.ForeColor = Color.LightBlue;
            cellStyle.SelectionForeColor = Color.Black;
            cellStyle.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Underline);
            dataGridView.Columns[1].DefaultCellStyle = cellStyle;
