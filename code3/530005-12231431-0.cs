    class MyData {
       public string StrA { get; set; }
    }
    // These only need to be setup once
    // But it will be "ok" now if they are called multiple times
    bw.WorkerSupportsCancellation = true;
    bw.DoWork += bw_DoWork;
    bw.RunWorkerCompleted += bw_RunWorkerCompleted);
    
    // pass data
    bw.RunWorkerAsync(new MyData {
        StrA = stra,
    });
    void bw_DoWork (object sender, DoWorkEventArgs e) {
        var data = (MyData)e.Argument;
        var stra = data.StrA;
        // stuff
    }
