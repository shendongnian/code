    Keys KeyCode; //This is the variable we will use to store the KeyCode gathered from the KeyDown event into. Then, check if it matches any of the arrow keys under SplitterMoving event canceling the movement if the result was true
    splitContainer1.KeyDown += new KeyEventHandler(splitContainer1_KeyDown); //Link the KeyDown event of splitContainer1 to splitContainer1_KeyDown
    splitContainer1.SplitterMoving += new SplitterCancelEventHandler(splitContainer1_SplitterMoving); //Link the SplitterMoving event of splitContainer1 to splitContainer1_SplitterMoving
   
    private void splitContainer1_SplitterMoving(object sender, SplitterCancelEventArgs e)
    {
        if (KeyCode == Keys.Up || KeyCode == Keys.Down || KeyCode == Keys.Left || KeyCode == Keys.Right) //Continue if one of the arrow keys was pressed
        {
            e.Cancel = true; //Cancel the splitter movement
        }
    }
    private void splitContainer1_KeyDown(object sender, KeyEventArgs e)
    {
        KeyCode = e.KeyCode; //Set KeyCode to the KeyCode of the event
     // e.Handled = true; //Handle the event
    }
