    button_Click(object sender, EventArgs e)
    {
       try
       {
          // Do stuff
       }
       catch(Exception exception)
       {
          // Couldn't do stuff. Log the exception.
          myTextBox.Text += "\n" + exception.Message;
       }
    }
