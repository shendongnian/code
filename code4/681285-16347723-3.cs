    TextBox getNewTextBox(int i)
    {
    	var tb = new TextBox();
    	tb.Location = new System.Drawing.Point(220, 90 + i * 24);
    	tb.Name = "tb_" + i.ToString();
    	tb.Size = new System.Drawing.Size(80,20);
    	tb.Text = "textbox_"+i.ToString(); //String.Empty;			
    	tb.Leave += new System.EventHandler(this.TextBox_LeaveEvent);
    	this.Controls.Add(tb);
    	this.Refresh();
    	return tb;
    }
