    ThreadPool.QueueUserWorkItem((s) =>
    {
        var keeprunning = true;
        sourceStream.RecordingStopped += (rss, rse) => { keeprunning = false; };
        while(keeprunning)
        {
            if (writebuffer.Count==0)
            {
                    Thread.Sleep(0);
            }
            else
            { 
                var buf = writebuffer.Dequeue();
                waveWriter.Write(buf,0,buf.Length);
                // Thread.Sleep(100); // for testing 
            }
        }
        waveWriter.Dispose();
        waveWriter = null;
    });
