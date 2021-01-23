        private CancellationToken cancelTokenOfFilterTask;
        private CancellationTokenSource cancelTokenSourceOfFilterTask = new CancellationTokenSource();
     
        private void FilterVolts()
        {
            if (IsApplicationWorking)
            {
                cancelTokenSourceOfFilterTask.Cancel();
            }
            // Prepare CancelToken
            cancelTokenOfFilterTask = cancelTokenSourceOfFilterTask.Token;
            IsApplicationWorking = true;
            if (SelectableVolts != null && SelectableVolts.Count >= 0)
            {
                VoltThatIsSelected = null;
                SelectableVolts.Clear();
            }
            Task voltsLoadTask = null;
            voltsLoadTask = Task.Factory.StartNew<List<SelectableVoltsModel>>(() => {
                VehicleLoader loader = new VehicleLoader();
                Thread.Sleep(2000); // just for testing, so the task runs a "long" time
                var listOfVolts = loader.LoadVoltsOnFilter(_sourceOfCachableData, ChosenFilter);
                return listOfVolts;
            }, cancelTokenOfFilterTask).ContinueWith(listSwitcher =>
            {
                switch (listSwitcher.Status)
                {
                    case TaskStatus.RanToCompletion:
                        SelectableVolts = new ObservableCollection<SelectableVoltModel>(listSwitcher.Result);
                        IsApplicationWorking = false;
                        break;
                    case TaskStatus.Canceled:
                        cancelTokenSourceOfFilterTask = new CancellationTokenSource(); // reset Source
                        break;
                    default:
                        break;
                }
            });
        }
