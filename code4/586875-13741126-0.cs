    List<string> items = GetListOfPdfFilesToProcess();
    int numCores = 4;
    int maxListChunkSize = (int)Math.Ceiling(items.Count / (double)numCores);
    ManualResetEvent[] events = new ManualResetEvent[numCores];
    for (int i = 0; i < numCores; i++)
    {
        ThreadPool.QueueUserWorkItem(ProcessFiles, new object[]
        {
            items.Skip(i * maxListChunkSize).Take(maxListChunkSize).ToList(), events[i]
        });
    }
    WaitHandle.WaitAll(events);
    ....
    private static void ProcessFiles(object state)
    {
        object[] stateArray = (object[])state;
        List<string> filePaths = (List<string>)stateArray[0];
        ManualResetEvent completeEvent = (ManualResetEvent)stateArray[1];
        for (int i = 0; i < filePaths.Count; i++)
        {
            csCommon.pdfFilesCompressAndMove(your parameters);
        }
        completeEvent.Set();
    }
