        String MasterFilterExp = "";        
        var tempCollection = (from String sFilt in RadGrid1.MasterTableView.FilterExpression.Split(new string[] {"AND"},StringSplitOptions.None)
                           where sFilt.Contains("[columnnameoffilteryouwantremoved]") != true 
                           select sFilt).ToArray();
        MasterFilterExp = string.Join(" AND ", tempCollection);
        foreach (GridColumn column in RadGrid1.MasterTableView.Columns)
        {
            if (column.UniqueName == "columnnameoffilteryouwantremoved")
            {                
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = String.Empty;
            }            
        }
        RadGrid1.MasterTableView.FilterExpression = MasterFilterExp;
        RadGrid1.Rebind();                        
