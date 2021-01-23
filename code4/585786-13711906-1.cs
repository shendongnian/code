    private void ParallelGenerateUI()
    {
        Dispatcher.BeginInvoke(DispatcherPriority.Background, (Action)delegate()
        {
           _UI = GenerateUI();
            RaisePropertyChanged("UI");
        });
    }
