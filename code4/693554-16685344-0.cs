    public partial class _Default : System.Web.UI.Page
    {
        public product p;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            p = new product();
            p.ProductId = 1;
            p.productName = "t-shirt";
    
        }
    
        public class product
        {
            public int ProductId { get; set; }
            public string productName { get; set; }
        }
    }
