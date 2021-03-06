    protected override void OnAutoGeneratedColumns(EventArgs e)
        {
            var dataTable = pivotMod.DataTable;
            foreach (DataGridColumn gridCol in Columns)
            {
                var colName = gridCol.Header.ToString();
                DataColumn col = dataTable.Columns[colName];
    
                // set the datacontext of the gridcolumn to the modfield ...
                ModFieldGUIWrapper modField = col.ExtendedProperties["ModField"] as ModFieldGUIWrapper;
                gridCol.SetValue(FrameworkElement.DataContextProperty, modField);
    
                // set the header to the data object so that the datatrigger's binding works!!
                gridCol.Header = modField;
    
            }
            base.OnAutoGeneratedColumns(e);
        }
