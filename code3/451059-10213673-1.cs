    if (!processing)
    {
        processing = true;
        VB.SetSource(new PhotoCamera());
        var bw = new BackgroundWorker();
        bw.DoWork += (object, sender) => {
            Thread.Sleep(250);
            processing = false;
        }
    }
