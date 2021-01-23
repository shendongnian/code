    public partial class ABC_UserControls_Pagination : System.Web.UI.UserControl
    {
        public string ListControlID { get; set; }
        public int ListPageCount { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void uxDataPager_Init(object sender, EventArgs e)
        {
            uxDataPager.PagedControlID = ListControlID;
            uxDataPager.PageSize = ListPageCount;
        }
    
        protected void uxDataPager_PreRender(object sender, EventArgs e)
        {
            // Custom Logic Here
        }
    }
