    for (int i = selectedRange.Rows.Count; i > 0; i--)
    {
      firstSelectedItem = ((ExcelIntOp.Range)selectedRange.Cells[i, 1]);
      if (firstSelectedItem.Value2 == null)
      {
          firstSelectedItem.EntireRow.Delete(System.Type.Missing);
          firstSelectedItem = ((ExcelIntOp.Range)selectedRange.Cells[i, 1]);
      }
    }
    firstSelectedItem.Select();
