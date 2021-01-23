    public partial class ProductDetail : System.Web.UI.Page
    {
    Cart crt = new Cart();
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void datalistProductDetail_ItemCommand(object source, DataListCommandEventArgs e)
    {
        switch (e.CommandName)
         {
            case "Add":
                DataListItem item1 = e.Item;
                int id = int.Parse((item1.FindControl("idLabel") as Label).Text);
                string name = (item1.FindControl("nameLabel") as Label).Text;
                double price = double.Parse((item1.FindControl("priceLabel") as Label).Text);
                string image = ((item1.FindControl("img") as Image).ImageUrl.Replace("~/images/sp/", ""));
                crt.addProductToCart(id, image, name, price);
                setCartToSession(crt);
                break;
        }
    }
    protected void setCartToSession(Cart crt)
    {
        List<Cart> dt = new List<Cart>();
        if (Session["cart"] != null)
        {
            dt.AddRange((List<Cart>)Session["Cart"]);
        }
        dt.Add(crt);
        Session["Cart"] = dt;
    }
    }
