    private void ReportToStatus(string message)
    {
        _statusList.AddLast(message);
        // textStatus is a textbox.
        // And this is the exact line that is giving the error:
        bgwTest.ReportProgress(0, _statusList.ToArray());
    }
    //Assuming this is the method handling bgwTest's ProgressChanged event
    private void bgwTest_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
         textStatus.Lines = (string[])(e.UserState);
    }
