    private static void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        aTimer.Enabled = false;
        try
        {
            // excutes some code
        }
        catch(Exception ex)
        {
            // log the exception and possibly rethrow it
            // Attention: never swallow exceptions!
        }
        finally
        {
            aTimer.Enabled = true;
        }
    }
