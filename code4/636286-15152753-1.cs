    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication1
    {
        public partial class Default : System.Web.UI.Page
        {
            [Serializable]
            public class Product
            {
                public int PID { get; set; }
                public string Name { get; set; }
    
                public Product(int i) { this.PID = i; this.Name = "product " + i.ToString(); }
            }
    
            [Serializable]
            public class CartItem
            {
                public Product Prod { get; set; }
                public int Qty { get; set; }
    
                public CartItem(Product p, int q) { this.Prod = p; this.Qty = q; }
            }
    
            public List<CartItem> myCart = new List<CartItem>();
            public List<CartItem> MyCart
            {
                get
                {
                    if (ViewState["cart"] == null)
                    {
                        ViewState["cart"] = new List<CartItem>();
                    }
    
                    return ViewState["cart"] as List<CartItem>;
                }
            }
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                    BindProdGrid();
            }
    
            protected void BindProdGrid()
            {
                gvProd.DataSource = GetProducts();
                gvProd.DataBind();
            }
    
            protected List<Product> GetProducts()
            {
                var ret = new List<Product>();
    
                ret.Add(new Product(1));
                ret.Add(new Product(2));
    
                return ret;
            }
    
            protected void gvProd_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "AddToCart")
                {
                    var row = (e.CommandSource as LinkButton).NamingContainer as GridViewRow;
                    var ddl = row.FindControl("ddlQty") as DropDownList;
    
                    var qty = Convert.ToInt32(ddl.SelectedValue);
                    var pid = Convert.ToInt32(e.CommandArgument);
    
                    AddToCart(pid, qty, increase: true);
                    BindCartGrid(this.MyCart);
                }
            }
    
            protected void AddToCart(int pid, int qty, bool increase = false)
            {
                var cartItem = this.MyCart.Find(o => o.Prod.PID == pid);
                if (cartItem == null)
                    this.MyCart.Add(new CartItem(new Product(pid), qty));
                else
                    if (increase)
                        cartItem.Qty += qty;
                    else
                        cartItem.Qty = qty;
            }
    
            protected void gvProd_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    var item = e.Row.DataItem as Product;
    
                    var litNm = e.Row.FindControl("litNm") as Literal;
                    litNm.Text = item.Name;
    
                    var ddlQty = e.Row.FindControl("ddlQty") as DropDownList;
                    ddlQty.Items.Add(new ListItem("1", "1"));
                    ddlQty.Items.Add(new ListItem("10", "10"));
    
                    var lbnAdd = e.Row.FindControl("lbnAdd") as LinkButton;
                    lbnAdd.CommandArgument = item.PID.ToString();
                }
            }
    
            protected void BindCartGrid(List<CartItem> items)
            {
                gvCart.DataSource = items;
                gvCart.DataBind();
            }
    
            protected void gvCart_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    var item = e.Row.DataItem as CartItem;
    
                    var litNm = e.Row.FindControl("litNm") as Literal;
                    litNm.Text = item.Prod.Name + " (pid:" + item.Prod.PID.ToString() + ")";
    
                    var txtQty = e.Row.FindControl("txtQty") as TextBox;
                    txtQty.Text = item.Qty.ToString();
                    txtQty.Attributes["data-pid"] = item.Prod.PID.ToString();
                }
            }
    
            protected void gvCart_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                if (e.CommandName == "UpdateCart")
                {
                    var row = (e.CommandSource as Button).NamingContainer as GridViewRow;
                    var txtQty = row.FindControl("txtQty") as TextBox;
    
                    var qty = Convert.ToInt32(txtQty.Text);
                    var pid = Convert.ToInt32(txtQty.Attributes["data-pid"]);
    
                    AddToCart(pid, qty, increase: false);
                    BindCartGrid(this.MyCart);
                }
            }
        }
    }
