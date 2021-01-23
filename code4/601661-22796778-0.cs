        var qName = @".\private$\deep_den";
        
        if (!MessageQueue.Exists(qName))
        {
            var q = MessageQueue.Create(qName);
        }
        var single = new MessageQueue(qName);
        single.UseJournalQueue = true;
        single.DefaultPropertiesToSend.AttachSenderId = false;
        single.DefaultPropertiesToSend.Recoverable = true;
        single.Formatter = new XmlMessageFormatter(new[] { typeof(Data) });
        var count = 500;
        var watch = new Stopwatch();
        watch.Start();
        for (int i = 0; i < count; i++)
        {
            var data = new Data { Name = string.Format("name_{0}", i), Value = i };
            single.Send(new Message(data));
        }
        watch.Stop();
        Console.WriteLine("sent {0} msec/message", watch.Elapsed.TotalMilliseconds / count);
        Console.WriteLine("sent {0} message/sec", count / watch.Elapsed.TotalSeconds);
        var enu = single.GetMessageEnumerator2();
        watch.Reset();
        watch.Start();
        var queue = new MessageQueue(qName);
        queue.UseJournalQueue = true;
        queue.DefaultPropertiesToSend.AttachSenderId = false;
        queue.DefaultPropertiesToSend.Recoverable = true;
        queue.Formatter = new XmlMessageFormatter(new[] { typeof(Data) });
        List<Data> lst = new List<Data>();
        while (lst.Count != count && enu.MoveNext(TimeSpan.FromDays(1)))
        {
            var message = queue.ReceiveById(enu.Current.Id);
            lst.Add((Data)message.Body);
        }
        watch.Stop();
        Console.WriteLine("rcvd {0} msec/message", watch.Elapsed.TotalMilliseconds / count);
        Console.WriteLine("rcvd {0} message/sec", count / watch.Elapsed.TotalSeconds);
        Console.WriteLine("press any key to continue ...");
        Console.ReadKey();
