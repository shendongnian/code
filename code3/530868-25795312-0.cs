    public ActionResult ExportToCSV(CellSeparators? cellSeparator)
    {
      if(cellSeparator.HasValue)
      {
        CellSeparator separator = cellSeparator.Value;
      }
      /* ... */
    }
