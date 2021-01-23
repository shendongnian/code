         if (e.CommandName == "Edit")
            {
                if (GridView1.SelectedRow != null)
                {
                    //dataTable.Rows[GridView1.SelectedRow].BeginEdit();
                    //dataTable.Rows[GridView1.SelectedRow]["yourFieldName"] = newValue;
                    //dataTable.Rows[GridView1.SelectedRow].EndEdit();
                    //gridView.DataSource = dataTable;
                }
              //  GridViewRow row = GridView1.Rows[e.RowIndex];
        for(int i=0;i<GridView1.Rows.Count;i++)
    {
                Department = ((GridViewRow(((LinkButton)e.CommandSource).NamingContainer)).Cells[2].Text;
                txtPart.Text = GridView1.SelectedRow[i][0].Cells[1].Text;
               txtPart.Text = GridView1.Rows[i][0].Cells[2].Text;
               Response.Write(gv.Rows[i][0].Cells[0].Text); //consider you use bound field and the column you want to show its value is the first column.
            }
    }
