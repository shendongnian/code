    protected void Page_Load(object sender, EventArgs e) 
     {   
       cn = new SqlConnection(ConfigurationManager.ConnectionStrings     
       ["DbConnect"].ConnectionString);
       SqlCommand cmd = new SqlCommand("GetExamResults", cn);  
