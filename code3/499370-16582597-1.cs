    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["myconnectionstring"].ConnectionString);
    SqlCommand cmd;
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void ChangePassword1_ChangedPassword(object sender, EventArgs e)
    {
        cmd = new SqlCommand("update  Admin set Password ='" + ChangePassword1.ConfirmNewPassword + "' where userid = '" + Session["userid"] + "' and Password ='" + ChangePassword1.CurrentPassword + "'", con);
        cmd.Connection.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
}
