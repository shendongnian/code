    protected void gvPaymentDetails_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {
        string balanceQueryString =
            "SELECT SUM(AuthorizationAmount) AS Balance FROM dbo.CPSTransaction WHERE (ApplicationIDPrimary = '" + Request.QueryString["WSUID"] + "')";
        using (SqlConnection balanceConnection =
                   new SqlConnection(ConfigurationManager.ConnectionStrings["OrientationConnectionString"].ConnectionString))
        {
            SqlCommand balanceCommand =
                new SqlCommand(balanceQueryString, balanceConnection);
            balanceConnection.Open();
            SqlDataReader balanceReader = balanceCommand.ExecuteReader();
            if (balanceReader.HasRows)
            {
                balanceReader.Read();
                litBalance.Text = balanceReader["Balance"].ToString();
            }
            // Call Close when done reading.
            balanceReader.Close();
        }
    }
