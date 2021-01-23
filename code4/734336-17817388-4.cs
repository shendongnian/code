    MessageDialog errorDialog = null;
    try
    {
        await DoSomething();
    }
    catch(InvalidOperation ex)
    {
        MessageDialogDisplayer.DisplayDialog(new MessageDialog(ex.Message));
    }
    catch(CommunicationException)
    {
        MessageDialogDisplayer.DisplayDialog(new MessageDialog(StringResourceLoader.LoginError));
    }
