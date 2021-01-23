    progBar.Height = 15;
    progBar.Width = 100;
    progBar.IsIndeterminate = true;
    statusBar.Items.Add(progBar);
    var files = Directory.EnumerateFiles(targetDirectory, "*.*", SearchOption.AllDirectories)
                .Where(s => extensions.Contains(System.IO.Path.GetExtension(s))) // "extensions" has been specified further above in the code
                .ToObservable(TaskPoolScheduler.Default)
                .Do(x => myDataSet.myTable.AddTableRow(System.IO.Path.GetFileNameWithoutExtension(x), x, "default")) // my table has 3 columns
                .TakeLast(1)
                .Do(_ => myDataSetmyTableTableAdapter.Update(myDataSet.myTable))
                .ObserveOnDispatcher()
                .Subscribe(xy =>
                    {
                        //progBar.Value++; //commented out since I've switched to a marquee progress bar
                    },
                    () =>
                    {
                        statusBar.Items.Remove(progBar);
                        btnCancel.Visibility = Visibility.Collapsed;
                    });
