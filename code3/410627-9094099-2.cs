    using (SqlConnection sqlConnection = new SqlConnection("..."))
    {
        sqlConnection.Open();
        string strSQL = "Select youthclubname from youthclublist WHERE ([YouthClubID] = @YouthClubID)";
        using (SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection))
        {
            sqlCommand.Parameters.AddWithValue("@YouthClubID", Request.QueryString["club"]);
            txtClubName.Text = sqlCommand.ExecuteScalar() + "";
        }
    }
