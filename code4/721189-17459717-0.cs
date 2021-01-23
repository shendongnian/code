    string ageQuery = "SELECT age FROM student WHERE username='" + Session["user"] + "'"
    string connString = ConfigurationManager.ConnectionStrings("con").ConnectionString;
    using (SqlConnection sqlConnection = new SqlConnection(connString))
    using (SqlCommand sqlCommand = new SqlCommand(ageQuery, sqlConnection))
    {
        sqlConnection.Open();
        lbl_agecurrent.Text = (com.ExecuteScalar).ToString();
    }
