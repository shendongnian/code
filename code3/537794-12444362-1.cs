    public void myButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            // the button click event executes even if the page isn't
            // valid, so you have to wrap your save event
            // in this kind of if block to avoid saving bad data to
            // to the database.
        }
    }
