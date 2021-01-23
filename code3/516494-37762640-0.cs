    Color farbe;
    string ph = "Placeholder-Text";
    
    private void Form1_Load(object sender, EventArgs e)
    {
        farbe = myTxtbx.ForeColor;
        myTxtbx.GotFocus += RemoveText;
        myTxtbx.LostFocus += AddText;
        myTxtbx.Text = ph;
    }
    
    
    public void RemoveText(object sender, EventArgs e)
    {
        myTxtbx.ForeColor = farbe;
        if (myTxtbx.Text == ph)
            myTxtbx.Text = "";
    }
    
    public void AddText(object sender, EventArgs e)
    {
        if (String.IsNullOrWhiteSpace(myTxtbx.Text))
        {
            myTxtbx.ForeColor = Color.Gray;
            myTxtbx.Text = ph;
        }
    }
