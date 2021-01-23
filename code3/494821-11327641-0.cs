    SqlConnection con=new SqlConnection("Data Source=ANURAG-PC;Initial Catalog=dbPortal;Persist Security Info=True;User ID=sa;Password=anurag");
        SqlDataAdapter da;
        DataSet ds=new DataSet();
        static DataTable dt=new DataTable();
    
    
            protected void Page_Load(object sender, EventArgs e) 
            {
                if (IsPostBack == false)
                {
                    string s = Request.QueryString["cat"];
                    string s1 = Request.QueryString["sub"];
    
    
                    da = new SqlDataAdapter("select * from '"+s+"' where subcategory3='" + s1 + "'",con);
                    da.Fill(ds);
                    dt = ds.Tables[0];
                    DataGrid1.DataSource = dt;
                    DataGrid1.DataBind();
    
                }
    
    
    
            }
