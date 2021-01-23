    try
    {
       myCustomWebbrowser.Navigate("yahoo.com");
    }
    catch(Exception ex) //catch specific exceptions here (catch all is a bad practice)
    {
       MessageBox.Alert(ex.Message); //just for testing.
    }
