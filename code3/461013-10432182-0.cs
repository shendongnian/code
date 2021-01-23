     if (!dr_art_line.Table.Columns.Contains("BarcodeIssueUnit"))
     {
         BarcodeIssueUnit = "";
     }
     else
     {
          BarcodeIssueUnit = dr_art_line["BarcodeIssueUnit"].ToString();
     }
    
     
