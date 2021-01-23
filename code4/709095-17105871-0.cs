    for (int i = 0; i < maxlabels ; i++)
    {                
        Label x = new Label();
        x.Name = string.Format("label{0}", i);
        x.AutoSize = true;`
        x.Top = 2 + (x.Height * i);
        x.Left = 3;
        x.Text = x.Name;
        x.BringToFront();
        x.BackColor = Color.Transparent;
        panel1.Controls.Add(x);                
    }
