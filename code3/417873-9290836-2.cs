    protected void Page_Load()
    {
        for (int i = 0; i < int.Parse(textBox1.Text); i++)
           {
              Button bt = new Button();
              bt.Text = "ok";
              bt.Click += new EventHandler(bt_click);
              this.Controls.Add(bt);
           }
    }
