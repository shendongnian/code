    try
    {
    ...
    }
    catch(Exception ex)
    {
        Log(ex.Message);
        MessageBox.Show("Error Occured. Please try again later."); //General message to the user 
    }
    finally
    {
        Cleanup... like Disposing objects (like com objects) if they need to be disposed.
    }
