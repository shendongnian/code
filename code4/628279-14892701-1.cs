    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
       {
          string ConnectString = "server=localhost;database=pubs;integrated security=SSPI";
          string QueryString = "select * from authors";
    
          SqlConnection myConnection = new SqlConnection(ConnectString);
          SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, myConnection);
          DataSet ds = new DataSet();
          myCommand.Fill(ds, "Authors");
    
          Select1.DataSource = ds;
          Select1.DataTextField = "au_fname";
          Select1.DataValueField = "au_fname";
          Select1.DataBind();
       }
    }
