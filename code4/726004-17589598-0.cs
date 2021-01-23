    protected void Page_Load(object sender, EventArgs e)
        {
    
            Button newButton = new Button();
            // Assign some text and an ID so you can retrieve it later. 
            newButton.Text = "* Dynamic Button *";
            newButton.ID = "newButton";
            PlaceHolder1.Controls.Add(newButton);
        }
