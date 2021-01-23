    MessageDialog errorDialog = null;
    try
    {
        await DoSomething();
    }
    catch(InvalidOperation ex)
    {
        errorDialog = new MessageDialog(ex.Message);
    }
    catch(CommunicationException)
    {
        errorDialog = new MessageDialog(StringResourceLoader.LoginError);
    }
    
    if (errorDialog != null)
    	await errorDialog.ShowAsync();
