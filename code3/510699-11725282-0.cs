    private void Button_Click(object sender, RoutedEventArgs e)
    { 
        try 
        {
             StreamSocketListener listener = new StreamSocketListener();
             greetingOutput.Text = "Hello, " + nameInput.Text + "!";
        } 
        catch(UnauthorizedAccessException exc) 
        {
             // Act on the missing capability. Log it and/or warn the user.
        }
    }
