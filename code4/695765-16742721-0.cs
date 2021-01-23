    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel panel1 = new Panel();
        Label newLabel = new Label();
        newLabel.ID = "lbltest";
        newLabel.Text = "my new label..";
        panel1.Controls.Add(newLabel);
        //Do this
        SomeControlOnYourPage.Controls.Add(panel1);
    }
