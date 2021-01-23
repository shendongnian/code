    protected void Page_Load(object sender, EventArgs e)
    {
        ImageButton btn = new ImageButton();
        btn.Command += btnOne_Click;
        form1.Controls.Add(btn);
    
        ImageButton btn2 = new ImageButton();
        btn2.Command += btnTwo_Click;
        btn2.Visible = false;
        form1.Controls.Add(btn2);
    }
    
    void btnOne_Click(object sender, EventArgs e)
    {
        // Your second button 
        form1.Controls[2].Visible = true;
    }
    
    void btnTwo_Click(object sender, EventArgs e)
    {
        ImageButton btn2 = (ImageButton)sender;
        // Do something
    }
