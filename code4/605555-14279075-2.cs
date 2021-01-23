    private void DoWork()
    {
        List<ManualResetEvent> events = new List<ManualResetEvent>();
        //in case you need to loop through multiple email addresses 
        //use the foreach here, assuming that the items is a list.
        //foreach(var item in items)
        //{
        var resetEvent = new ManualResetEvent(false);
        ThreadPool.QueueUserWorkItem(arg =>
        {
            SendMail(node.Attributes["id"].Value.ToString(), 
               node["fname"].InnerText + " " + node["lname"].InnerText,
               500, node["email"].InnerText);
            resetEvent.Set();
        });
        events.Add(resetEvent);
        //} <- closes the foreach loop
        //WaitHandle.WaitAll waits for all the threads to finish.
        WaitHandle.WaitAll(events.ToArray());
        MessageBox.Show("Mails are sent", "Notification");
    }
