        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit_Mob") {
            GridViewRow row = (GridViewRow (((ImageButton)e.CommandSource).NamingContainer);
            int RowIndex = row.RowIndex; // this find the index of row
            int varName1 = Convert.ToInt32(((Label)row.FindControl("lbl_mobile_id")).Text.ToString()); //this store the  value in varName1
 
            }
       }
