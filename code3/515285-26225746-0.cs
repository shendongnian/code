    private void gridCategories_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == gridCategories.Columns["AddCategory"].Index)
        {
            //do some stuff
        }
    }
       
    private void gridCategories_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.ColumnIndex == gridCategories.Columns["AddCategory"].Index)
        {
            gridCategories.EndEdit();
        }
    }
