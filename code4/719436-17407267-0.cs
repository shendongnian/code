    protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
                //int userid = Convert.ToInt32(gvDetails.DataKeys[e.RowIndex].Values["UserId"].ToString());
                string id = gvDetails.DataKeys[e.RowIndex].Values["ID"].ToString();
    
    
    
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Department_Master where id=" + id, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
    
                DataTable dt = ds.Table[0];
                for (int i = 0; i < dt.rows.count; i++)
                {
                    string imgPath = "Images/Departments/" + "" + dt.rows[i]["DepartmentName"] + "/";
                    bool IsExists = System.IO.Directory.Exists(Server.MapPath(imgPath));
                    if (IsExists)
                        System.IO.Directory.Delete(Server.MapPath(imgPath));
                }
    
                con.Close();
    
    
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Department_Master where ID=" + id, con);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result == 1)
                {
                    BindEmployeeDetails();
                    lblresult.ForeColor = Color.Red;
                    lblresult.Text = id + " details deleted successfully";
                }
            }
