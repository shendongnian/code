        protected void DropDownServerName_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database_Shared_NotebookConnectionString"].ConnectionString);
    
            conn.Open();
    
            string serverName = DropDownServerName.SelectedValue;
    
            string sqlquery = ("SELECT Architecture FROM tblServer WHERE (ServerName = "' + serverName + '")");
    
            SqlCommand command = new SqlCommand(sqlquery, conn);
    
            txtUpdateArchitecture.Text = command.ExecuteScalar().ToString();
    
            conn.Close();
        }
