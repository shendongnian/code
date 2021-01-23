    protected void Page_Init(object sender, EventArgs e)
    {
        // Create View.
        View myView = new View();
        // Create controls.
        Label myLabel = new Label();
        myLabel.Text = "<b>Test</b>";
        // Add controls to View.
        myView.Controls.Add(myLabel);
        //Add view to MultiView.
        MultiView1.Views.Add(myView);
        MultiView1.ActiveViewIndex = 0;
    }
