    BackgroundWorker worker = sender as BackgroundWorker;
    
    foreach (string rep in (IEnumerable<string>)e.Argument)
    {
        if (worker.CancellationPending == true)
        {
            e.Cancel = true;
            return;
        }
        else
        {
            DirectoryExists(rep);
            ProcessRunner(rep); //Rars some large files - expensive
        }
    }
