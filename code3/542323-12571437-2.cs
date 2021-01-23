    // assume there is a class Products with id and ProductName
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product() { ID = 1, ProductName = "asdf" });
            products.Add(new Product() { ID = 2, ProductName = "asdf" });
            products.Add(new Product() { ID = 3, ProductName = "jklö" });
            products.Add(new Product() { ID = 4, ProductName = "asdf" });
            gvProducts.DataSource = products;
            gvProducts.DataBind();
        }
    }
