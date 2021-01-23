    public Form1()
    {
        // Add a "CheckedChanged" event handler for each radio button.
        // Ensure that all radio buttons are in the same groupbox control.
        radioButton1.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
        radioButton2.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
    }
    
    private void radioButtons_CheckedChanged (object sender, EventArgs e)
    {
        // Do stuff only if the radio button is checked (or the action will run twice).
        if (((RadioButton)sender).Checked)
        {
            if (((RadioButton)sender) == radioButton1)
            {
                // Do stuff 
            }
            else if (((RadioButton)sender) == radioButton2)
            {
                // Do other stuff
            }
        }
    }
