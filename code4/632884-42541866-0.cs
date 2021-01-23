    int cleft = 1;
    intaleft = 1;
    private void button2_Click(object sender, EventArgs e) 
    {
    	 TextBox txt = new TextBox();
    	 this.Controls.Add(txt);
    	 txt.Top = cleft * 40;
    	 txt.Size = new Size(200, 16);
    	 txt.Left = 150;
    	 cleft = cleft + 1;
    	 Label lbl = new Label();
    	 this.Controls.Add(lbl);
    	 lbl.Top = aleft * 40;
    	 lbl.Size = new Size(100, 16);
    	 lbl.ForeColor = Color.Blue;
    	 lbl.Text = "BoxNo/CardNo";
    	 lbl.Left = 70;
    	 aleft = aleft + 1;
    	 return;
    }
    private void btd_Click(object sender, EventArgs e)
    { 
    	//Here you Delete Text Box One By One(int ix for Text Box)
    	for (int ix = this.Controls.Count - 2; ix >= 0; ix--)
    	//Here you Delete Lable One By One(int ix for Lable)
    	for (int x = this.Controls.Count - 2; x >= 0; x--)
    	{
    		if (this.Controls[ix] is TextBox) 
    		this.Controls[ix].Dispose();
    		if (this.Controls[x] is Label) 
    		this.Controls[x].Dispose();
    		return;
    	}
    }
