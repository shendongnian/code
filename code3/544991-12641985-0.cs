    protected void GridView3_DataBound(object sender, EventArgs e)
        {           
            foreach (GridViewRow row in GridView3.Rows)
            {
                Label label1 = (Label)row.FindControl("Label1"); //ID of the ItemTemplate for my column to which I want ToolTip
                string label2 = label1.Text.Trim();
                if (label2.Length != 0)
                {
                    con.Open();
                    string str = "SELECT Location_Profile_Tool_Tip FROM Location_Profile_List_ToolTip WHERE Location_Profile_Name='" + label2 + "'";
                    SqlCommand cmd = new SqlCommand(str, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        row.Cells[2].ToolTip = dr[0].ToString().Trim();
                    }
                    con.Close();
                }
            }
        }
