    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            if (con.State == System.Data.ConnectionState.Closed)
            {
            con.Open();
            }
            SqlDataAdapter adp = new SqlDataAdapter("SELECT name from Master where id= 10"), con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            Label2.Text = Convert.ToString(ds1);
        }
    }
    protected String CodeBehind()
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT name from Master where id= 10"), con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        String ds2 = Convert.ToString(ds1);
        Label2.Text = ds2;
        return (ds2);
    }
