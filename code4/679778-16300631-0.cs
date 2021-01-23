        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
    
                    int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex]["userid"]);
                    string City= ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.Trim();
                    string Designation = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.Trim();
    
                    SqlCommand cmd = new SqlCommand("update Employee_Details set City='" + City + "',Designation='" + Designation + "' where UserId=" + userid, con);
                    // 
                    // other Code snippets
                    //
                    GridView1.EditIndex = -1;
                    BindGridview();
                   
        }
