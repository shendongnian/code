    // Flag to keep the state open/close of the child form
    private bool childClosed = true;
    private void newDocument_ItemClick(object sender, ClickEventArgs e)
    {
        if(childClosed == true)
        {
            Form2 formChild = new Form2();
            // Setup the event handler form the Form2 closing directly here in the MDI
            formChild.FormClosing += new FormClosingEventHandler(myFormClosing);
            formChild.Show();
            
            // set the flag to avoid the reopening
            childClosed = false;
        }
    }
    // Now, when the formChild closes, you will receive the event directly here in the MDI
    private void myFormClosing(object sender, FormClosingEventArgs e)
    {
        // The child form is closing......
        // Do your update here, but first check the close reason
        if(e.CloseReason == CloseReason.UserClosing)
        {
           ......
           // reset the flag so you could reopen the child if needed
           childClosed = true;
        }
    }
