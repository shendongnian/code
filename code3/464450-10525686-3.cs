        var newline = System.Environment.NewLine;
        var tab = "\t";
        var clipboard_string = new StringBuilder();
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            for (int i = 0; i < row.Cells.Count; i++)
            {
                if (i == (row.Cells.Count - 1))
                    clipboard_string.Append(row.Cells[i].Value + newline);
                else
                    clipboard_string.Append(row.Cells[i].Value + tab);
            }
        }
        Clipboard.SetText(clipboard_string.ToString());
