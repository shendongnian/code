        StateChecker stillWorking = () => { return bw.IsBusy; };
        if (bw.IsBusy)
        {
            bw.CancelAsync();
            while ((bool)this.Dispatcher.Invoke(stillWorking, null)) Thread.Sleep(15);
        }
        bw.RunWorkerAsync();
