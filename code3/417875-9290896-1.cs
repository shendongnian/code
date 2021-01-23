    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            for (int i = 0; i < int.Parse(TextBox1.Text); i++)
            {
                CreateButton(i);
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
    }
    protected void bt_click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        Label1.Text = btn.Text + " Clicked";
    }
    private void CreateButton(int id)
    {
        Button bt = new Button();
        bt.Text = "ok" + id.ToString();
        bt.Click += new EventHandler(bt_click);
        bt.ID = "btn" + id.ToString();
        this.Form.Controls.Add(bt);
    }
