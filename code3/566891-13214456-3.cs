     protected void Page_Load(object sender, EventArgs e)
                {
                    if(!Page.IsPostBack)
                    {
                     List<Product> lst = new List<Product>();
                     lst.Add(new Product(){Title="title 1", SmallImage = "some path"});
                     lst.Add(new Product(){Title="title 2", SmallImage = "some "});
                     myGrid.DataSource = lst;
                     myGrid.DataBind();
                    }
 
                }
