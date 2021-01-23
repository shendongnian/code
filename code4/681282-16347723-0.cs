    List<TextBox> textboxList = new List<TextBox>();
    void TextBox_LeaveEvent(object sender, EventArgs e)
    {    	
    	var tb = getNewTextBox(textboxList.Count);
    	if(textboxList.Count<3)
    		textboxList.Add(tb);    	
    }
    
    
    TextBox getNewTextBox(int i)
    {
    	var tb = new TextBox();
    	tb.Location = new System.Drawing.Point(10, 90 + i * 24);
    	tb.Name = "tb_" + i.ToString();
    	tb.Size = new System.Drawing.Size(80,20);
    	tb.TabIndex = i + 2;
    	button1.TabIndex = i + 3;
    	tb.Text = i.ToString(); //String.Empty;			
    	tb.Enter += new System.EventHandler(this.TextBox_Enter);
    	this.Controls.Add(tb);
    	this.Refresh();
    	return tb;
    }
    
    // remove the last textbox if it does not contain any text
    // still with bugs
    void Button_Enter(object sender, EventArgs e)
    {
    	// still a bug --> removes the wrong textbox (1 index to early)
    	var tb = textboxList[textboxList.Count-1];
    	label1.Text = "tb: " + tb.Name + " (" + tb.Text.Length +")";
    	if(tb.Text.Length==0){
    		// this.Controls.RemoveByKey(tb.Name);				
    		int tbIndex = this.Controls.IndexOf(tb);
    		this.Controls[tbIndex].Dispose();
    	}
    }
