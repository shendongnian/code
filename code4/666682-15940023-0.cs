    private void bgw_DoWork(object sender, DoWorkEventArgs e)
    {
        try
        {
            // do the work
        }
        catch (Exception ex) // on error 
        {
            e.Error = ex;
            e.Result = "set the data here";
        }
    }
