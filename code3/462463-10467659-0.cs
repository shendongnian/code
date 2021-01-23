    public void DoIt(Action ThingToDo) {
        ComponentViewModel.Instance.IsApplicationBusy = true;
        ComponentViewModel.Instance.BusyMessage = "Loading...";
        var loadProviderTask = Task.Factory.StartNew(Action);
        loadProviderTask.ContinueWith(antecdent =>
        {
            ComponentViewModel.Instance.IsApplicationBusy = false;
        }
    }
