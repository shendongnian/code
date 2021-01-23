    var retries = new HashSet<RetryingMessage<TInput>>();
    
    TransformManyBlock<RetryableMessage<TInput>, TOutput> target = null;
    target = new TransformManyBlock<RetryableMessage<TInput>, TOutput>(
        async message =>
        {
            try
            {
                var result = new[] { await transform(message.Data) };
                retries.Remove(message);
                
                // Sets the state of the event to signaled, allowing one or more waiting threads to proceed
                if(!retries.Any()) Signal.Set(); 
                return result;
            }
            catch (Exception ex)
            {
                message.Exceptions.Add(ex);
                if (message.RetriesRemaining == 0)
                {
                    if (failureHandler != null)
                        failureHandler(message.Exceptions);
    
                    retries.Remove(message);
                    
                    // Sets the state of the event to signaled, allowing one or more waiting threads to proceed
                    if(!retries.Any()) Signal.Set(); 
                }
                else
                {
                    retries.Add(message);
                    message.RetriesRemaining--;
    
                    Task.Delay(retryDelay)
                        .ContinueWith(_ => target.Post(message));
                }
                return null;
            }
        }, dataflowBlockOptions);
    
    source.LinkTo(target);
    
    source.Completion.ContinueWith(async _ =>
    {
        //Blocks the current thread until the current WaitHandle receives a signal.
        target.Signal.WaitOne();
    
        target.Complete();
    });
