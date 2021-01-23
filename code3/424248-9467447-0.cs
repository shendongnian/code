    if (!Page.IsPostBack)
    {
        Button b = new Button();
        b.Click += new EventHandler(b_Click);
    }
    void b_Click(object sender, EventArgs e)
    {
         throw new NotImplementedException();
    }
