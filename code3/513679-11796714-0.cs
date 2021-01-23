        Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
        xlApp.Visible = true;
        xlApp.Workbooks.Add(misValue);
        int nWS = xlApp.ActiveWorkbook.Worksheets.Count;
        for (int i = nWS; i < l.Count; i++)
            xlApp.ActiveWorkbook.Worksheets.Add(misValue, misValue, misValue, misValue);
        int iWS = 1;
        foreach (float[] ff in l)
        {
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)xlApp.ActiveWorkbook.Worksheets[iWS++];
            int idxRow = 1;
            foreach (float aFloat in ff)
                ws.Cells[idxRow++, 1] = aFloat;
        }
