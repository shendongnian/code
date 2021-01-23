    void Main()
    {
        var subject = new Subject<Message>();
        var sequence = subject.Publish().RefCount().Prioritize();
        
        Action<Message, int> subscriber = (m, priority) =>
        {
            if (!m.IsConsumed)
            {
                m.IsConsumed = true;
                Console.WriteLine(priority);
            }
        };
    
        var s3 = sequence.PrioritySubscribe(3, Observer.Create<Message>(m => subscriber(m, 3)));
        var s2 = sequence.PrioritySubscribe(2, Observer.Create<Message>(m => subscriber(m, 2)));
        var s1 = sequence.PrioritySubscribe(1, Observer.Create<Message>(m => subscriber(m, 1)));
        var s11 = sequence.PrioritySubscribe(1, Observer.Create<Message>(m => subscriber(m, 1)));
        
        subject.OnNext(new Message()); // output: 1
        
        s1.Dispose();
        subject.OnNext(new Message()); // output: 1
        s11.Dispose();
        
        subject.OnNext(new Message()); // output: 2
        s2.Dispose();
        subject.OnNext(new Message()); // output: 3
        
        sequence.Dispose();
    
    }
