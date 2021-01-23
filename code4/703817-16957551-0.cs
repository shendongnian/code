    for (int i = 1; i <= 10; i++)
    {
        Label lblc = new Label();
        lblc.Text = i.ToString();
        lblc.Name = "Test" + i.ToString(); //Name used to differentiate the control from others.
        this.Controls.Add(lblc);
    }
    //To Enumerate added controls
    foreach(Label lbl in this.Controls.OfType<Label>())
    {
        .....
        .....
    }
