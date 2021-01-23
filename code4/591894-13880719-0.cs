    private void button1_Click(object sender, EventArgs e)
    {
        thisButton = sender as Button;
    
        buttoncount++;
    
        SwitchTagWithText(thisButton);
    
        if (buttoncount == 1)
        {
            lastButton = thisButton;
        }
        else if (buttoncount == 2)
        {
            if (lastButton.Tag == thisButton.tag)
            {
                // Disable both buttons.
            }
            else
            {
                // Switch buttons back
            }
    
            buttoncount = 0;
        }
    }
