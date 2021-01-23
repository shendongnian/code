    private void HandleButtonClick(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        if(btn.Tag == "Hello")
          MessageBox.Show("Hello")
        else if(btn.Tag == "Goodbye")
           Application.Exit();
        // etc.
    }
