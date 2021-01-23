    protected void Page_Load(object sender, EventArgs e)
        {
            RadAutoCompleteBox1.DataSource = new List<string>() { "Europe", "America", "Asia", "Africa", "Australia" };
            RadAutoCompleteBox2.DataSource = new List<string>();
        }
