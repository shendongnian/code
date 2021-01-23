        TextBox txtRun = new TextBox();
        //...
        string n = c.ToString();
        txtRun.Name = "textname" + n;
    
    
        txtRun.Location = new System.Drawing.Point(10, 20 + (10 * c));
        txtRun.Size = new System.Drawing.Size(200, 25);
        this.Controls.Add(txtRun);
