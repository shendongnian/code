    private void newDocument_ItemClick(object sender, ClickEventArgs e)
    {
        Form2 formChild = new Form2();
        // Setup the event handler form the Form2 closing directly here in the MDI
        formChild.FormClosing += new FormClosingEventHandler(myFormClosing);
        formChild.Show();
    }
    // Now, when the formChild closes, you will receive the event directly here in the MDI
    private void myFormClosing(object sender, FormClosingEventArgs e)
    {
        // The child form is closing......
        // Do your update here, but first check the close reason
        if(e.CloseReason == CloseReason.UserClosing)
        {
           ......
        }
    }
