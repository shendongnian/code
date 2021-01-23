    private void AssessmentButton_Click(object sender, EventArgs e)
    {
        int length = (int)this.NoAssesmentBoxlv4.Value;
        for (int i = 0; i < length; i++)
        {
            TextBox t = new TextBox();
            System.Drawing.Point p = new System.Drawing.Point(110, 260 + i * 25);                     
            t.Location = p;
            t.Size = new System.Drawing.Size(183, 20);
            
            Button b = new Button();
            b.Location = new System.Drawing.Point(380, 260 + i * 25);
            b.Text = @"x";
            b.BackColor = Color.Red;
            b.ForeColor = Color.White;
            b.Size = new System.Drawing.Size(22, 23);
            b.Click += new System.EventHandler(this.buttoRemove_click);
            
            this.Lv4Tab.Controls.Add(t);
            this.Lv4Tab.Controls.Add(b);
            textboxAssesmentName.Add(t);
            buttoRemove.Add(b);
        }
    }
    
    private void buttoRemove_click(object sender, EventArgs e)
    {
        Control b = sender as Control;
        Control t = b.Tag as Control;
        this.Lv4Tab.Controls.Remove(t);
        this.Lv4Tab.Controls.Remove(b);
        textboxAssesmentName.Remove(t);
        buttoRemove.Remove(b);
    }
