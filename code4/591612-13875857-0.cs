    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      if (previousKeyEvent != null)
      {
        if (previousKeyEvent.Modifiers == Keys.Control && previousKeyEvent.KeyCode == Keys.W && previousKeyEvent.e == Keys.O)
        {
          MessageBox.Show("Ctrl + W then O");
        }
        else
        {
          MessageBox.Show("Not handled");
          previousKeyEvent = null;
        }
      else
        previousKeyEvent = e;
      }
    }
