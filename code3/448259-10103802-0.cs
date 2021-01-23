    Task<byte[]> getData = new Task<byte[]>(() => GetFileData());
    Task<double[]> analyzeData = getData.ContinueWith(x => Analyze(x.Result));
    Task<string> reportData = analyzeData.ContinueWith(y => Summarize(y.Result));
    getData.Start();
    
                //or...
    Task<string> reportData2 = Task.Factory.StartNew(() => GetFileData())
                  .ContinueWith((x) => Analyze(x.Result))
                  .ContinueWith((y) => Summarize(y.Result));
