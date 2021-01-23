    Cars car1;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        car1 = new Cars();
        car1.Name = "Chevy";
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
       TextBox1.Text = car1.Name.ToString();
    }
