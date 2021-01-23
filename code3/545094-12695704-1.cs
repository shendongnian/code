    //masterpage search button click
    protected void btnMasterSearch_Click(object sender, EventArgs e)
        {
            //input is from the user's entry in text box
            string input = txtMasterSearch.Text;
            //result is filtered by regex then added to url for search
            string result = Regex.Replace(input, @"[^\w\.@-]", "");
            try
        {
            if (String.IsNullOrEmpty(result))
            {
                throw new ArgumentException("Null is not allowed");
            }
            else
            {
                Response.Redirect("Search.aspx?search=" + result);
            }
    //search.aspx
    public partial class Search : System.Web.UI.Page
    {
        public string productparam;//product parameter to add to url
        public string searchparam;//search parameter from url
    protected void Page_Load(object sender, EventArgs e)
        {
                  searchparam = Request.QueryString["search"];
                  GetProducts();
        }
    private void GetProducts()
        {
            try
            {
                DataSet ds = DataAccess.GetProductsPerCategory(searchparam);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (SqlException ex)
            {
            lblSearch.Text = "Cannot get product data." + ex.Message;
            }
        }
    protected void Button2_Click(object sender, EventArgs e)
            //button in gridview, sends to item detail page
        {
            LinkButton btn = (LinkButton)(sender);
            productparam = btn.CommandArgument;
            Server.Transfer("ItemDetail.aspx?product=" + productparam);
        }
    //item detail page
    public partial class ItemDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblISBN.Text = Request.QueryString["product"];
            }
            catch (Exception ex)
            {
            lblISBN.Text = "Cannot get product data." + ex.Message;
            }
        }
     }
