    splitContainer1.KeyDown += new KeyEventHandler(splitContainer1_KeyDown); //Link the KeyDown event of splitContainer1 to splitContainer1_KeyDown
    private void splitContainer1_KeyDown(object sender, KeyEventArgs e)
    {
      //  if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right) //Continue if one of the arrow keys was pressed
      //  {
              
              e.Handled = true; //Handle the event
      //  }
    }
