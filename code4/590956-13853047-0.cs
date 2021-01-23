    protected void Button1_Click(object sender, EventArgs e)
    {
    
        Button clickedButton = sender as Button;
        if (clickedButton == null) // just to be on the safe side
            return;
    
        if (clickedButton.ID == "Button1")
        {
        }
        else if(clickedButton.ID == "Button2")
        {
        }
    }
