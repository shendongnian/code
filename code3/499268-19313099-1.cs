    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        obj1.Id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
        obj1.Name = ((TextBox)row.Cells[1].Controls[1]).Text;
        obj1.Description = ((TextBox)row.Cells[2].Controls[1]).Text;
        obj1.Updatetbl();
        GridView1.EditIndex = -1;
        bindGvEdit();
    }
