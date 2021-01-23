        bool compareTbls(Datatable OldDataTable , Datatable NewDataTable )
    {
      if(OldDataTable .Rows.Count != NewDataTable .Rows.Count || OldDataTable .Columns.Count != NewDataTable .Columns.Count)
        return false;
    
      for(int i = 0; i < OldDataTable .Rows.Count; i++)
      {
        for(int c = 0; c < OldDataTable .Columns.Count; c++)
        {
          if(OldDataTable .Rows[i][c] != NewDataTable .Rows.Columns[i][c])
            return false;
        }
      }
      return true;
    }
