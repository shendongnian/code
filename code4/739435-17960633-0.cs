    // Form method for updating progress bar; callable from worker thread
    public void UpdateProgressBar(double progress)
    {
        // dispatch the update onto the form's thread
        Dispatcher.BeginInvoke((Action<double>)((n) =>
        {
            // do the update in the form's thread
            progressBar1.Value = n;
        }), progress);
    }
