    public partial class Edit : System.Web.UI.UserControl
    {
        public Produit MyObject { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.product.Text = MyObject.ProductName;
            this.Production.Text = MyObject.Production.ToString();
        }
    }
