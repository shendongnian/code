    private BlockingCollection<string> OutputQueue = new BlockingCollection<string>();
    void SomeMethod()
    {
        var outputTask = Task.Factory.StartNew(() => WriteOutput(outputFilename),
            TaskCreationOptions.LongRunning);
        OutputQueue.Add("A simulated entry");
        OutputQueue.Add("more stuff");
        // when the program is done,
        // set the queue as complete so the task can exit
        OutputQueue.CompleteAdding();
        // and wait for the task to finish
        outputTask.Wait();
    }
    void WriteOutput(string fname)
    {
        using (var strm = File.AppendText(filename))
        {
            foreach (var s in OutputQueue.GetConsumingEnumerable())
            {
                strm.WriteLine(s);
                // if you want to make sure it's written to disk immediately,
                // call Flush. This will slow performance, however.
                strm.Flush();
            }
        }
    }
