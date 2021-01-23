    // In the ReasonableDelay method
    .Subscribe(_ => {}, () => {        
        if(!subscription.IsDisposed) // Check for unsubscribe
        {
            Console.WriteLine("Waiting to subscribe to source");
            // Artifical sleep to create a problem            
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine("Subscribing to source");
            // Is this line safe?                    
            subscription.Disposable = source.Subscribe(observer);
        }
    }); 
