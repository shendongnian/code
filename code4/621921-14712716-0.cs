    List<Category> categoryList = new List<Category>();
    public Main(string firstname, string lastname, string status)
    {
        InitializeComponent();
        label1.Text = (firstname+lastname+status).Trim();
        string connection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Trgovina.mdf;Integrated Security=True";
        SqlConnection cn = new SqlConnection(connection);
        try 
        {
            cn.Open();
        }
        catch (Exception) { MessageBox.Show("Error occurred during database communication!"); }
        string sqlQuery = "SELECT * FROM Kategorije_art";
        SqlCommand categoryCommand = new SqlCommand(sqlQuery, cn);
        SqlDataReader categoryDataRead = categoryCommand.ExecuteReader();
        categoryList.Add(new Category(1, "a")); //ERROR ?!
    }
