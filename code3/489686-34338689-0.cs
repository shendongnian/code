    var applicationWord = new Microsoft.Office.Interop.Word.Application();
                applicationWord.Visible = true;
                Word.Document wordDoc = applicationWord.Documents.Add();
                var cells = getCells();
                var last_row = cells.Row;
                var last_col = cells.Column;
                var firstcell = activeWorksheet1.get_Range("A1", Type.Missing);
                var lastcell = (Excel.Range)activeWorksheet1.Cells[last_row, last_col];
    
                activeWorksheet.Range[firstcell, lastcell].Copy(); // All Active cell will get copied
                wordDoc.ActiveWindow.Selection.PasteExcelTable(false, false, false);
