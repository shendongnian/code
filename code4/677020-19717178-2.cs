    tableLayoutPanel.SuspendLayout();
    while (tableLayoutPanel.RowCount > 1)
    {
        int row = tableLayoutPanel.RowCount - 1;
        for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
        {
            Control c = tableLayoutPanel.GetControlFromPosition(i, row);
            tableLayoutPanel.Controls.Remove(c);
            c.Dispose();
        }
        tableLayoutPanel.RowStyles.RemoveAt(row);
        tableLayoutPanel.RowCount--;
    }
    tableLayoutPanel.ResumeLayout(false);
    tableLayoutPanel.PerformLayout();
