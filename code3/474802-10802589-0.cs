        public void onProjectSelected()
        {
            string cs = ConfigurationManager.ConnectionStrings["CSLinker"].ConnectionString;
            string projectName = txtSearchInput.Text;
            int projectID = 0;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand("SELECT ProjectID FROM TabProjects WHERE Name = @Name", connection))
                {
                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 50)).Value = projectName;
                    connection.Open();
                    if (int.TryParse(command.ExecuteScalar().ToString(), out projectID))
                    {
                        Response.Redirect(string.Format("?ProjectID={0}", projectID));
                    }
                    connection.Close();
                }
            }
            //Handle project not found events here
        }
