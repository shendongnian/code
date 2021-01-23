    // in this example this is scoped to the class, but just scope it appropriately
    private BackgroundWorker worker = new BackgroundWorker();
    
    ......
    // because I don't really know anything about how your program is structured I'm not sure
    // where you want to place all of the definitions OR where you want to place RunWorkerAsync
    // but you want the definitions to happen ONCE and the RunWorkerAsync to be where the USER
    // initiates it
    
    // this will allow you to consume the ProgressChanged event
    worker.WorkerReportsProgress = true;
    
    // this will allow you to set the CancellationPending property
    worker.WorkerSupportsCancellation = true;
    
    worker.DoWork += (o, args) =>
    {
        foreach (ListViewItem item in bufferedListView1.Items) 
        { 
            string lname = bufferedListView1.Items[i].Text; 
            string lno = bufferedListView1.Items[i].SubItems[1].Text; 
            string gname = bufferedListView1.Items[i].SubItems[2].Text; 
            string line = lname + "@" + lno + "@" + gname; 
            if (gname.Contains(sgroup)) 
            { 
                var m = Regex.Match(line, @"([\w]+)@([+\d]+)@([\w]+)"); 
                if (m.Success) 
                { 
                    port.WriteLine("AT+CMGS=\"" + m.Groups[2].Value + "\""); 
                    port.Write(txt_msgbox.Text + char.ConvertFromUtf32(26)); 
                    Thread.Sleep(4000); 
                } 
                sno++; 
            } 
            i++; 
        }
    }
    
    worker.ProgressChanged += (s, args) =>
    {
        // set some progress here, the ProgressChangedEventArgs inherently supports an integer
        // progress via the ProgressPercentage property
    }
    
    worker.RunWorkerCompleted += (s, args) =>
    {
        // with the RunWorkerCompletedEventArgs class you can check for errors via Error, did
        // cancellation occur via Cancelled, and you can even send a complex result via the Result
        // property - whatever you need
    }
    
    // this starts the work in the DoWork event handler
    worker.RunWorkerAsync();
