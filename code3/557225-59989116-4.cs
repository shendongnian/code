    private void DataGridView_AutoSize()
    {
       var col = dataGridView.Columns;
    
       for (int i = 0; i < col.Count; i++)
       {
          if (i == 0) { col[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; }
          if (i == 1) { col[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; }
          // Etc...
        }
    }
    
