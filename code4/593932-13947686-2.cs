    Public string gethiddenexcellcolumns()
    {     
   
        Excel.Application excel = New Excel.Application();
        excel.Visible = True;
        excel.Workbooks.Add();
        excel.Columns("C:C").Select();
        excel.Selection.EntireColumn.Hidden = True;
        var columns = excel.Columns;
        bool hasHiddenColumns = false;
        foreach(column in columns)
        {
            If(column.Hidden==true)
            {
                hasHiddenColumns = true
            }            
        }
        return "excel.Columns.Hidden = " + hasHiddenColumns.ToString();
    }
