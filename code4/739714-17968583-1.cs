    public partial class WebForm1 : System.Web.UI.Page
    {
        // Hold the original datatable from database
        System.Data.DataTable OriginalDataTable = null; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindGridView("");
        }
    
        void BindGridView(string searchQuery )
        {
        
            GridView1.DataSource = GetSelectionResult(searchQuery);
            GridView1.DataBind(); 
            
        }
        
        private void initialData()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["defaultconnection"].ConnectionString;
            string query = "select * from Ressources";
            
            OriginalDataTable = new DataTable(); 
            
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connectionString))
            {
                dataAdapter.Fill(OriginalDataTable); 
            }
        
        }
    
    
        DataView GetSelectionResult(string searchParam)
        {
            if (OriginalDataTable == null)
                initialData();
        
            if (string.IsNullOrEmpty(searchParam))
                return OriginalDataTable.DefaultView;
        
            string rowFilter = string.Format("data like '%{0}%'", searchParam);
            return new DataView(OriginalDataTable, rowFilter, "data", DataViewRowState.OriginalRows); 
        
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            BindGridView(TextBox1.Text); 
        }
        
        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            //...
        }
        
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGridView(TextBox1.Text); 
        }
        
    }
