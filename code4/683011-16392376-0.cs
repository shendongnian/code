    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["Test"] != null) 
      {
        Session["Test"] = TextBox1.Text;
        
      }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
      TextBox1.Text = Session["Box"].ToString();
    }
