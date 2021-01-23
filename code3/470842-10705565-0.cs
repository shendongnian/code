    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
        TextBox1.Text = %YOUR_INITIAL_DB_VALUE%;
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
      string userInput = TextBox1.Text;
      TextBox1.Text = %YOUR_NEW_DB_VALUE%;
    }
