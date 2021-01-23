    private void button1_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["modelConnectionString"].ConnectionString;
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
		{
			sqlConnection.Open();
			using (SqlCommand connect = new SqlCommand("SELECT COUNT(*) From Users WHERE UserName = @user AND Password = @pass", sqlConnection))
			{
				SqlParameter username = connect.Parameters.AddWithValue("@user", userName.Text);
				SqlParameter password = connect.Parameters.AddWithValue("@pass", passWord.Text);
				if ((int)connect.ExecuteScalar() == 1)
				{
					accessPic.BackgroundImage = Res.Accepted;
				}
				else
				{
					accessPic.BackgroundImage = Res.Denied;
				}
			}
		}
    }
