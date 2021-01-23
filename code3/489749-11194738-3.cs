     protected void Page_Load(object sender, EventArgs e)
     {
        if (Session["Page1Value"] != null)
        {
           Label1.Text = Session["Page1Value"].ToString();
        }
     }
