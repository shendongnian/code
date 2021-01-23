    private void grd_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
      switch (e.ColumnIndex)
      {
        case 7:
        case 8:
          e.Value = string.Empty;
          e.FormattingApplied = true;
          break;
      }
    }
