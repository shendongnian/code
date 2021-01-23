    //number of WorkerProcess
    int numWorkerProcess = 5;
    //Create MemroyMappedFile object and accessor. 4 means int size.
    MemoryMappedFile mmf = MemoryMappedFile.CreateNew("test_mmf", 4);
    MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor();
    EventWaitHandle ChangeEvent = new EventWaitHandle(false, EventResetMode.ManualReset, counterName + "_Event");
            
    //write counter to MemoryMappedFile
    accessor.Write(0, numWorkerProcess);
    //.....
    ChangeEvent.Set();
    //spin wait until all workerProcesses decreament counter
    SpinWait.SpinUntil(() => {
        int numLeft = accessor.ReadInt32(0);
        return (numLeft == 0);
    });
    ChangeEvent.Reset();
