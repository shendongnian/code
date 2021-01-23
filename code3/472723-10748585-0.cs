    foreach (object possibleSheet in xlApp.Sheets)
    {
        Microsoft.Office.Interop.Excel.Worksheet aSheet = possibleSheet as Microsoft.Office.Interop.Excel.Worksheet;
        if (aSheet == null)
            continue;
    
        // your stuff here
    }
