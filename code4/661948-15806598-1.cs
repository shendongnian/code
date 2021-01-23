    protected void Page_Load(object sender, EventArgs e)
    {
    con = new MySqlConnection("Data Source=localhost;Database=YourDatabase Name;User ID=root;Password=YourPasssword");
    con.Open();
    Response.Write("connect");
    }
