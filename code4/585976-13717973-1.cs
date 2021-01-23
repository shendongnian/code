    public class Foo
    {
        public int Stock { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Foo> fooList = new List<Foo>()
            {
                    new Foo(){ Stock=3},
                    new Foo(){ Stock=5}
            };
            ListView1.ItemDataBound += (sa, ea) =>
                {
                    int stock = int.Parse((ea.Item.FindControl("Stock") as Label).Text);
                    DropDownList stockQty = ea.Item.FindControl("StockQty") as DropDownList;
    
                    for (int i = 0; i <= stock; i++)
                        stockQty.Items.Add(i.ToString());
                };
    
            ListView1.DataSource = fooList;
            ListView1.DataBind();
        }
    }
