    ITargetBlock<DateTimeOffset> CreateNeverEndingTask(
        Func<DateTimeOffset, CancellationToken, Task> action, 
        CancellationToken cancellationToken)
    {
        // Validate parameters.
        if (action == null) throw new ArgumentNullException("action");
        // Declare the block variable, it needs to be captured.
        ActionBlock<DateTimeOffset> block = null;
        // Create the block, it will call itself, so
        // you need to separate the declaration and
        // the assignment.
        // Async so you can wait easily when the
        // delay comes.
        block = new ActionBlock<DateTimeOffset>(async now => {
            // Perform the action.  Wait on the result.
            await action(now, cancellationToken).
                // Doing this here because synchronization context more than
                // likely *doesn't* need to be captured for the continuation
                // here.  As a matter of fact, that would be downright
                // dangerous.
                ConfigureAwait(false);
            // Wait.
            await Task.Delay(TimeSpan.FromSeconds(10), cancellationToken).
                // Same as above.
                ConfigureAwait(false);
            // Post the action back to the block.
            block.Post(DateTimeOffset.Now);
        }, new ExecutionDataflowBlockOptions { 
            CancellationToken = cancellationToken
        });
        // Return the block.
        return block;
    }
