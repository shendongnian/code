    private void ViewRolesDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (ViewRolesDataGrid.Columns[e.ColumnIndex].Name == "Avatar")
        {
            DataGridViewRow row = ViewRolesDataGrid.Rows[e.RowIndex];
    
            Guid iconGuid = (Guid)row.Cells["ID_Picture"].Value;
    
            Image icon = null;
    
            if (MyIcons.Icons32x32.ContainsKey(iconGuid))                
            {
                icon = (Image)MyIcons.Icons32x32[iconGuid];
            }
    
            if(icon != null)
            {
                DataGridViewImageCell cell = row.Cells["Avatar"] as DataGridViewImageCell;
    
                cell.Value = icon;
            }              
        }
    }
