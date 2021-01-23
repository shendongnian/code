    void cancelTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
       try
       {
            populateGridAssetsWorker.CancelAsync();
            cancelTimer.Stop();
            AfMainWindow.MainWindow.UpdateStatusBar("Could not load assets, timeout error");
            MessageBox.Show("Operation Timed Out\n\nThe Server did not respond quick enough, please try again",
                            "Timeout", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
            AfMainWindow.MainWindow.Busy.IsBusy = false;
        }
        catch(Exception ex)
        {
            int breakpoint = 42;
        }
    }
