    protected void Page_Load(object sender, EventArgs e) 
    {
        if(!Page.IsPostBack)
        {
            List<Product> list = new List<Product>();
            Product prod = new Product();
            // set the properties
            list.Add(prod);
            // add other products
            gridView1.DataSource = list;
            gridView1.DataBind();
        }
    }
