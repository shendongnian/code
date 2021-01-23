       var cell = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[row, column];
       cell.Validation.Delete();
       cell.Validation.Add(
          XlDVType.xlValidateInputOnly,
          Type.Missing,
          Type.Missing,
          Type.Missing,
          Type.Missing);
       cell.Value = "";
       cell.Validation.IgnoreBlank = false;
       cell.Validation.InCellDropdown = false;
