    using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["websiteContent"].ConnectionString))
    {
        sqlCon.Open();
        string SQL = "SELECT COUNT(*) As LoginFound FROM CMS_Users " + 
                     "WHERE CMS_Username =@usr AND CMS_Password = @pwd";
        using (SqlCommand sqlComm = new SqlCommand(SQL, sqlCon))
        {
            sqlComm.Parameters.AddWithValue("@usr", userName);
            sqlComm.Parameters.AddWithValue("@pwd", password);
            int result = (int)sqlComm.ExecuteScalar();
            if (result > 0)
            {
                // In case of success you need to communicate this 
                e.Authenticated = Authenticated;
                FormsAuthentication.SetAuthCookie(Login1.UserName, true);
                Response.Redirect("cms.aspx");
            }
            else
            {
                Session["UserAuthentication"] = "";
            }
        }
    }
