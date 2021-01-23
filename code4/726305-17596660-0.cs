        ...
        ...
        SqlExpressDownloader.RunWorkerCompleted += SqlExpressDownloader_RunWorkerCompleted;
        SqlExpressDownloader.RunWorkerAsync();
    }
    private void SqlExpressDownloader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            // do something in response to the error
        }
        // stuff to do after DoWork has completed
    }
