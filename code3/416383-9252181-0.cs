    protected void Page_Load(object sender, EventArgs e)
    {
     if(!IsPostBack)
     {
      Session["userID"] = Request.QueryString["id"];
        SqlConnection cn = new SqlConnection();
        cn.ConnectionString = ds.ConnectionString;
        cn.Open();
        SqlCommand cm = new SqlCommand();
        cm.Connection = cn;
        cm.CommandText = "select * from Users where UserID='" + Session["userID"].ToString() + "'";
        SqlDataReader dr;
        dr = cm.ExecuteReader();
        if (dr.Read())
        {
            uname.Text = dr["username"].ToString();
            fname.Text = dr["Fullname"].ToString();
            per.SelectedValue = dr["Permission"].ToString();
            email.Text = dr["Email"].ToString();
            phone.Text = dr["phone"].ToString();
        }
        else Response.Redirect("Default.aspx");
        dr.Close();
        cn.Close();
     }
    }
