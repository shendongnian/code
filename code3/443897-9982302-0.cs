    //Declare this outside of the loop
    bool hasDisplayed = false;
    //Inside the timer event handler
    if (!hasDisplayed && DateTime.Now >= newDateTime)
    {
        hasDisplayed = true;
    
        MessageBox.Show("!!!!!!!!!!!!!");
    }
