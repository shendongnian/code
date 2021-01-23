    public partial class WebForm1 : System.Web.UI.Page
    {
        public String name,type,rvw;
        public void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Uz!\Documents\Data_Ware.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select * From CoffeeDB  ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView.DataSource = dt;
        }
    }
