    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
    excel.Workbooks.Add(System.Reflection.Missing.Value);
    int rowIdx = 2;
    foreach (CFolderType ft in FolderTypes) 
    {
        Microsoft.Office.Interop.Excel.Range aCell = excel.get_Range("A" + rowIdx.ToString(), System.Reflection.Missing.Value); 
        aRange.Value = ft.name;
        rowIdx++;
    }
