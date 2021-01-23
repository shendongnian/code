         protected void GridView1_SelectedIndexChanged(object sender,EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            int g = row.RowIndex + 3;
            int current_row_index = row.RowIndex;
             
            foreach (GridViewRow gvRow in GridView1.Rows)
            {
                gvRow.BackColor = Color.White;
                if (gvRow.FindControl("nameOfTheDropdown") != null && gvRow.RowIndex != current_row_index)
                {
                    ((DropDownList)gvRow.FindControl("nameOfTheDropdown")).SelectedIndex = 0;
                }
            }
            GridView1.Rows[g].BackColor = Color.Red;  
         }
