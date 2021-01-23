        Excel.Application excel = New Excel.Application();
        excel.Visible = True;
        excel.Workbooks.Add();
        excel.Columns("C:C").Select();
        excel.Selection.EntireColumn.Hidden = True;
        c= excel.Columns;
        public bool hasHiddenColumns;
        foreach(c in columns)
        {
            If(column.Hidden==true)
            {
                hasHiddenColumns = 1
            }            
        }
        return("excel.Columns.Hidden = " + hasHiddenColumns.ToString())
}
