    FileDownloadHandler fileDownloadHandler = new FileDownloadHandler(downloadlocation);
    try
    {
        Button button = browser.Button(Find.ByText("Save"));
        browser.AddDialogHandler(fileDownloadHandler);
        button.ClickNoWait();
        fileDownloadHandler.WaitUntilFileDownloadDialogIsHandled(40);
        fileDownloadHandler.WaitUntilDownloadCompleted(200);
        fileDownloadHandler.WaitUntilDownloadCompleted(200);
    }
    catch (Exception excp)
    {
        /// Log exception message
    }
    finally
    {
        /// Remove the dialog handler
        browser.RemoveDialogHandler(fileDownloadHandler);
    }
