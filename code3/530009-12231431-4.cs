    class MyData {
       public string StrA { get; set; }
    }
    // These only need to be setup once (and should be for clarity).
    // However it will be "ok" now if they are called multiple times
    // as, since the delegates are the same, the += will
    // act as a replacement (as it replaces the previous delegate with itself).
    bw.WorkerSupportsCancellation = true;
    bw.DoWork += bw_DoWork;
    bw.RunWorkerCompleted += bw_RunWorkerCompleted;
    
    // Pass data via argument
    bw.RunWorkerAsync(new MyData {
        StrA = str,
    });
    void bw_DoWork (object sender, DoWorkEventArgs e) {
        var data = (MyData)e.Argument;
        var str = data.StrA;
        // stuff
    }
