    void Main()
    {
        // our simulated event stream
        var fakeSource = new System.Reactive.Subjects.Subject<StreamEvent>();
        
        // Let's use a scheduler we actually don't have to wait for
        var theTardis = new System.Reactive.Concurrency.HistoricalScheduler();
            
        var busySignal = fakeSource
            // Batch up events:
            .Window(
                // Starting batching on a busy signal
                fakeSource.Where(e => e.Type == EventType.Busy),
                // Stop batching on a not busy signal
                (open) => fakeSource.Where(e => e.Type == EventType.NotBusy)
                    // but throw a timeout if we exceed 5 seconds per window
                    .Timeout(TimeSpan.FromSeconds(5), theTardis))		
            // Unpack the windows
            .Switch()
            // Catch any timeout exception and inject a NULL into the stream		
            .Catch(fakeSource.StartWith((StreamEvent)null))
            // Bool-ify on "did a timeout happen?"
            .Select(e => e == null)
            // Start in an "unbusy" state
            .StartWith(false)
            // And only tell us about transitions
            .DistinctUntilChanged();	
    
        using(busySignal.Subscribe(signal => 
            Console.WriteLine("At {0}, Busy Signal Indicator is now:{1}",
                theTardis.Now,
                signal ? "ON" : "OFF")))
        {
            // should not generate a busy signal
            Console.WriteLine("Sending BUSY at {0}", theTardis.Now);
            fakeSource.OnNext(new StreamEvent(EventType.Busy));
            theTardis.AdvanceBy(TimeSpan.FromSeconds(2));
            Console.WriteLine("Sending NOTBUSY at {0}", theTardis.Now);
            fakeSource.OnNext(new StreamEvent(EventType.NotBusy));
            theTardis.AdvanceBy(TimeSpan.FromSeconds(1));
            Console.WriteLine();
    
            // should generate a busy signal
            Console.WriteLine("Sending BUSY at {0}", theTardis.Now);
            fakeSource.OnNext(new StreamEvent(EventType.Busy));
            theTardis.AdvanceBy(TimeSpan.FromSeconds(3));
            Console.WriteLine("Sending BUSY at {0}", theTardis.Now);
            fakeSource.OnNext(new StreamEvent(EventType.Busy));
            theTardis.AdvanceBy(TimeSpan.FromSeconds(3));
    
            // and this should clear it
            Console.WriteLine("Sending NOTBUSY at {0}", theTardis.Now);
            fakeSource.OnNext(new StreamEvent(EventType.NotBusy));		
            theTardis.AdvanceBy(TimeSpan.FromSeconds(1));
            Console.WriteLine();	
        }
    }
