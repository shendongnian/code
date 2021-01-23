    object CurrentName = com.ExecuteScalar();
    if (CurrentName != null && CurrentName != System.DBNull.Value) {
        {
            Session["UserAuthentication"] = (string)CurrentName;
            Session.Timeout = 1;
            Response.Redirect("Default.aspx");
        }
        else
        {
            Session["UserAuthentication"] = "";
        }
    }
