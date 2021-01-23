    Label lblc = new Label();
    
    for (int i = 1; i <= 10; i++)
    {
        lblc.Name = i.ToString();
        lblc.Text = i.ToString();
        this.Controls.Add(lblc);
    }
