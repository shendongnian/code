        using( ExcelPackage pck = new ExcelPackage( ) )
        {
          //Create the worksheet
          ExcelWorksheet ws = pck.Workbook.Worksheets.Add( "Sheet1" );
    
          // set the delimiter
          etf.Delimiter = ',';
          etf.EOL = "\n";
          etf.TextQualifier = "\"";
    
          //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
          ws.Cells["A1"].LoadFromText( csvData, etf );
          return pck.GetAsByteArray( );
       }
