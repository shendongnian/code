    comboBox.BeginInvoke(
        (Action)(() =>
        {
           for (int i = 0; i < dataTable.Rows.Count; i++)
           {
              comboBox.Items.Add(dataTable.Rows[i][0].ToString());
           }
        }));
