    public partial class _Default : System.Web.UI.Page
    {
    private SqlDataReader reader = null;
    public SqlDataReader Reader { get { return reader; } set { reader = value; } }
        protected void Page_Load(object sender, EventArgs e)
        {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
    
        SqlCommand command = new SqlCommand("SELECT * FROM uploads WHERE status IS NULL AND uploader = @uploader", connection);
            command.Parameters.Add(new SqlParameter("uploader", "anonymous"));
    
            Reader = command.ExecuteReader();
        }
    }
