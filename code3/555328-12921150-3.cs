        class FilterWrapper
        {
            public Telerik.Web.UI.GridKnownFunction GridColumnFilterFunc { get; set; }
            public string GridColumnFilterValue { get; set; }
        }
        Dictionary<String, FilterWrapper> FilterCollection = new Dictionary<String, FilterWrapper> { };
        String MasterFilterExp = "";
        foreach (GridColumn column in RadGrid1.MasterTableView.Columns)
        {
            FilterCollection.Add(column.UniqueName, new FilterWrapper { GridColumnFilterFunc = column.CurrentFilterFunction, GridColumnFilterValue = column.CurrentFilterValue });
        }
        var tempCollection = (from String sFilt in RadGrid1.MasterTableView.FilterExpression.Split(new string[] {"AND"},StringSplitOptions.None)
                           where sFilt.Contains("COLUMNWITHREMOVEDFILTER") != true 
                           select sFilt).ToArray();
        MasterFilterExp = string.Join(" AND ", tempCollection);
        foreach (GridBoundColumn column in RadGrid1.MasterTableView.Columns)
        {
            if (column.UniqueName != "COLUMNWITHREMOVEDFILTER")
            {
                FilterWrapper oFilterInfo = FilterCollection[column.UniqueName];
                column.CurrentFilterFunction = oFilterInfo.GridColumnFilterFunc;
                column.CurrentFilterValue = oFilterInfo.GridColumnFilterValue;
            }
            else
            {
                column.CurrentFilterFunction = GridKnownFunction.NoFilter;
                column.CurrentFilterValue = String.Empty;
            }
            
        }
        RadGrid1.MasterTableView.FilterExpression = MasterFilterExp;
        RadGrid1.Rebind();               
