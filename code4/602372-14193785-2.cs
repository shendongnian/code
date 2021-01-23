    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            if (con.State == System.Data.ConnectionState.Closed)
            {
            con.Open();
            }
            
            Label2.Text = CodeBehind();
        }
    }
    protected String CodeBehind()
    {
        SqlDataAdapter adp = new SqlDataAdapter("SELECT name from Master where id= 10"), con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        String ds2 = Convert.ToString(ds1);        
        return (ds2);
    }
