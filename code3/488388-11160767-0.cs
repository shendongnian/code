    public Form1()
    {
        radioButton1.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
        radioButton2.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
        // ...
    }
    private void radioButtons_CheckedChanged (object sender, EventArgs e)
    {
        RadioButton radioButton = sender as RadioButton;
        if (radioButton1.Checked)
        {
            // Do stuff 
        }
        else if (radioButton2.Checked)
        {
            // Do other stuff
        }
    }
