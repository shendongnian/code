    var pq = LocalPrintServer.GetDefaultPrintQueue();
    var theJob = pq.AddJob();
    try{
        using(var js = theJob.JobStream){
            var buffer = File.ReadAllBytes("yourPathToPdf");
            js.Write(buffer,0,buffer.Length);
        }
        var done=false;
        while(!done)
        {
            pq.Refresh();
            theJob.Refresh();
            done = theJob.IsCompleted || theJob.IsDeleted || theJob.IsPrinted;
        }
    }
    catch(Exception ex){
        //handle this
    }
    finally{
        theJob?.Dispose();
        pq?.Dispose();
    }
