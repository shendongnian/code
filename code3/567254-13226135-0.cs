    public void DeleteEverything(object sender, EventArgs e)
        {
            // this function is to delete the selected items based on the checkbox
            CheckBox chkAll = (CheckBox)GridView1.HeaderRow.FindControl("SelectAllCheck");
            // to get the Checkbox status in the header rows
            if (chkAll.Checked == true)
            {
                int i = 0;
                foreach (GridViewRow gvRow in GridView1.Rows)//to get all rows in that particular page
                {
                    string Delete = Convert.ToString(GridView1.Rows[i].Cells[3].Text);
                    //Cells[3] is the column to get one by one rows cells[3] columns where you should keep your primary keys and in visible state
                    Bal_add.Delete(Delete);
                    i++;
                }
                Response.Redirect("Information.aspx");
            }
            else
            {
                int j=0;
                foreach (GridViewRow gvRow in GridView1.Rows)
                {
                    CheckBox chkSel = (CheckBox)gvRow.FindControl("SelectCheck");
                    if (chkSel.Checked == true)
                    {
                        string Delete = Convert.ToString(GridView1.Rows[j].Cells[3].Text);
                        //Cells[3] is the column to get one by one rows cells[3] columns where you should keep your primary keys and in visible state
                        Delete(Delete);
                    
                    }
                    j++;
    
                }
                Response.Redirect("Information.aspx");
            }
               
        }
    public void Delete(string UserEmail)
            {
                obj_add = new add();
                string QueryString;
                QueryString = System.Configuration.ConfigurationManager.ConnectionStrings["Admin_raghuConnectionString1"].ToString();
    
                obj_SqlConnection = new SqlConnection(QueryString);
    
                obj_SqlCommand = new SqlCommand("usp_DeleteDataProcedure");
                obj_SqlCommand.CommandType = CommandType.StoredProcedure;
                obj_SqlConnection.Open();
    
                obj_SqlCommand.Parameters.AddWithValue("@UserEmail", UserEmail);//here @UserName is the variable that we declare in the stored procedure
                obj_SqlCommand.Connection = obj_SqlConnection;
                SqlDataReader obj_result = null;
    
                obj_SqlCommand.CommandText = "usp_DeleteDataProcedure";
                obj_result = obj_SqlCommand.ExecuteReader();
                obj_SqlConnection.Close();
              
            }
