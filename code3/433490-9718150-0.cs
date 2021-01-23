    for (int i = 0; i < 10; i = i + 1)
    {
        Button b = new Button();
        b.ID = "Button" + i;
        b.Click += new EventHandler(b_Click); 
        Controls.Add(b);
    }
    void b_Click(object sender, EventArgs e)
    {
        //some code
    }
