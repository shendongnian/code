    protected void Page_Load(object sender, EventArgs e) 
    { 
        if(!this.Page.IsPostback)
        {
            SourceDataContext db = new SourceDataContext(); 
     
            GridView1.DataSource = from q in db.Cust 
                                   orderby q.ID 
                                   select q; 
            GridView1.DataBind(); 
        }
    }
