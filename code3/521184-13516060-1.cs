        public IEnumerable<IResult> ProcessTask()
        {
            IsBusy = true;
            TempObject result = null;
            for (int i = 1; i < 4; i++) // Simulates a loop that processes multiple items, files, fields...
            {
                yield return new BackgroundCoRoutine(() =>
                {
                    System.Threading.Thread.Sleep(1000); // Time consuming task in another thread
                    result = new TempObject("Item " + i);
                });
                MyObservableCollection.Add(result); // Update the UI with the result, in the GUI thread
            }
            IsBusy = false;
        }
