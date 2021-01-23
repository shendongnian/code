     if (!String.IsNullOrEmpty(toolStripTextBox1.Text))
        {
          username = toolStripTextBox1.Text;
         MessageBox.Show(username); // will be the username the user enters in the textbox
         }
          else
        {
          MessageBox.Show(username); // will be the username taken from your config file
        }
