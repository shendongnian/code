    private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)  
    {
        if (e.Column.Caption == "Any2")
        {
            if (e.RowHandle == 0)
                e.RepositoryItem = columnReadOnlyTextEdit;
            else
                e.RepositoryItem = columnTextEdit;    
        }
    }
 
