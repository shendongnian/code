    private void tSEventsDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            //create new CellStyle
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            //if we have a value and that value is greater than the MaximumHoursWarning setting
            object cellValue = tSEventsDataGridView[eventTimeDataGridViewTextBoxColumn.Index, e.RowIndex].Value;
            if (cellValue is double
                && (double) cellValue > Timesheets.Properties.Settings.Default.MaximumHoursWarning)
                cellStyle.BackColor = Color.FromArgb(255, 220, 220);  //change the color to light red
            else if (e.RowIndex % 2 == 0)
                cellStyle.BackColor = Color.FromArgb(240, 240, 240);          //else keep the alternating background
            else
                cellStyle.BackColor = Color.White;
            //set the CellStyle for this row.
            tSEventsDataGridView.Rows[e.RowIndex].DefaultCellStyle = cellStyle;
        }
    }
