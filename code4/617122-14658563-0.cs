    ...
        me.WaitOne();
        main_engine.processCreatedFile();
    }
    ...
    void OnFileCreation(object sender, FileSystemEventArgs e) {
    // do some file processing
    // takes time based on size of file and whether file is locked or not etc.
    ...
    me.Set();
    }
    ManualResetEventSlim me = new ManualResetEventSlim(false);
