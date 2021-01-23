    public void finishConfigButton_Click()
    {
        worker = new BackgroundWorker();
        worker.DoWork += delegate(object s, DoWorkEventArgs args)
        {
            //Do the heavy work here
        };
        worker.RunWorkerCompleted += delegate(object s, RunWorkerCompletedEventArgs args)
        {
            //Things to do after the execution of heavy work
            validationProfile.IsBusy = false;
        };
        validationProfile.IsBusy= true;
        worker.RunWorkerAsync();
        }
    }
