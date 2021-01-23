    protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            int suggestionStatus = int.Parse(ddl.SelectedValue);
            GridViewRow row = (GridViewRow)ddl.NamingContainer;
            string strID = GridView1.DataKeys[row.RowIndex]["ID"];
            int ID = Int32.Parse(strID);
            //For inserting the status in the database
            string connString = "Data Source=localhost\\sqlexpress;Initial Catalog=psspdbTest;Integrated Security=True";
            string updateCommand = "UPDATE SafetySuggestionsLog  SET [StatusID] = @StatusID WHERE [ID] = @ID";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(updateCommand, conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@StatusID", suggestionStatus);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
