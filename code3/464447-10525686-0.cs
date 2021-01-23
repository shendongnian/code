        var newline = System.Environment.NewLine;
        var tab = "\t";
        string clipboard_string = "";
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
             for (int i=0; i < row.Cells.Count; i++)
             {
                  if(i == (row.Cells.Count - 1))
                       clipboard_string += row.Cells[i].Value + newline;
                  else
                       clipboard_string += row.Cells[i].Value + tab;
             }
        }
        Clipboard.SetDataObject(clipboard_string, true);
