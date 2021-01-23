    protected void Page_Init(object sender, EventArgs e)
    {
        Label label = new Label();
        label.ID = "myLabel";
        label.Text = "I am in the Place holder";
        PH.Controls.Add(label);
    }
    protected void brnClickme_Click(object sender, EventArgs e)
    {
        Label label = (Label)PH.FindControl("myLabel");
        label.Text = "After Click I am changed!";
    }
