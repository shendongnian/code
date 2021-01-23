    var fileTask = Task.Factory.StartNew( () =>
    {
        DirectoryInfo dir = new DirectoryInfo(MainFolder);
        return new List<FileInfo>(
               dir.EnumerateFiles("*.docx",SearchOption.AllDirectories)
               .Take(200) // In previous question, you mentioned only wanting 200 items
           );
    };
    // To process items:
    fileTask.ContinueWith( t =>
    {
         List<FileInfo> files = t.Result;
         // Use the results...
         foreach(var file in files)
         {
             this.listBox.Add(file); // Whatever you want here...
         }
    }, TaskScheduler.FromCurrentSynchronizationContext()); // Make sure this runs on the UI thread
    DoSomethingWhileWaiting();
