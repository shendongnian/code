    void AttachHandlers()
    {
        Panel panel1 = new Panel();
        panel1.Tag = "this is first panel";
        panel1.Click += new EventHandler(panel1_Click);
        flowLayoutPanel1.Controls.Add(panel1);
    }
    void func_2(string str)
    {
        label1.Text = str;
    }
    void panel1_Click(object sender, EventArgs e)
    {
        func_2(sender.Tag.ToString());
    }
