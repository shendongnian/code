    // Show the Cancel button to allow the user to abort the process
    btnCancel.Visibility = Visibility.Visible;
    // Set the Cancel click event as an observable so we can monitor it
    var cancelClicked = Observable.FromEventPattern<EventArgs>(btnCancel, "Click");
    // Use Rx to pick the scanned files from the IEnumerable collection, fill them in the DataSet and finally save the DataSet in the DB
    var files = Directory.EnumerateFiles(targetDirectory, "*.*", SearchOption.AllDirectories)
                .Where(s => extensions.Contains(System.IO.Path.GetExtension(s)))
                .ToObservable(TaskPoolScheduler.Default)
                .TakeUntil(cancelClicked)
                .Do(x => ....
