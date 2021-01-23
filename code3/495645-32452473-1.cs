    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection("data source=.;uid=sa;pwd=123;database=shop");
        //SqlCommand cmd = new SqlCommand("select * from tblemployees", con);
        //SqlCommand cmd1 = new SqlCommand("select * from tblproducts", con);
        //SqlDataAdapter da = new SqlDataAdapter();
        
        //DataSet ds = new DataSet();
        //ds.Tables.Add("emp");
        //ds.Tables.Add("products");
        //da.SelectCommand = cmd;
        //da.Fill(ds.Tables["emp"]);
        //da.SelectCommand = cmd1;
        
        //da.Fill(ds.Tables["products"]);
        SqlDataAdapter da = new SqlDataAdapter("select * from tblemployees", con);
        DataSet ds = new DataSet();
        da.Fill(ds, "em");
        da = new SqlDataAdapter("select * from tblproducts", con);
        da.Fill(ds, "prod");
        GridView1.DataSource = ds.Tables["em"];
        GridView1.DataBind();
        GridView2.DataSource = ds.Tables["prod"];
        GridView2.DataBind();
    }
