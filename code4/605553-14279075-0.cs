    List<ManualResetEvent> events = new List<ManualResetEvent>();
    var resetEvent = new ManualResetEvent(false);
    //Create local variable of the item.
    ThreadPool.QueueUserWorkItem(arg =>
    {
        SendMail(node.Attributes["id"].Value.ToString(), 
           node["fname"].InnerText + " " + node["lname"].InnerText,
           500, node["email"].InnerText);
        resetEvent.Set();
    });
    events.Add(resetEvent);
    
    //WaitHandle.WaitAll waits for all the threads to finish.
    WaitHandle.WaitAll(events.ToArray());
