        foreach(RichTextBox rbox in rboxarray)
        {
            
            rbox = new RichTextBox();
            Controls.Add(rbox);
            rbox.Location = new System.Drawing.Point(14, y);
            rbox.Name = "richTextBox"+ (12+j);
            rbox.Size = new System.Drawing.Size(671, 68);
            rbox.TabIndex = 41 + j;
            rbox.Text = "";
            y += 70;
            j++;
        }
