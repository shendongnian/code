    private static Task<PingReply> SendTaskCore(Ping ping, object userToken, Action<TaskCompletionSource<PingReply>> sendAsync)
        {
            // Validate we're being used with a real smtpClient.  The rest of the arg validation
            // will happen in the call to sendAsync.
            if (ping == null) throw new ArgumentNullException("ping");
            // Create a TaskCompletionSource to represent the operation
            var tcs = new TaskCompletionSource<PingReply>(userToken);
            // Register a handler that will transfer completion results to the TCS Task
            PingCompletedEventHandler handler = null;
            handler = (sender, e) => EAPCommon.HandleCompletion(tcs, e, () => e.Reply, () => ping.PingCompleted -= handler);
            ping.PingCompleted += handler;
            // Try to start the async operation.  If starting it fails (due to parameter validation)
            // unregister the handler before allowing the exception to propagate.
            try
            {
                sendAsync(tcs);
            }
            catch(Exception exc)
            {
                ping.PingCompleted -= handler;
                tcs.TrySetException(exc);
            }
            // Return the task to represent the asynchronous operation
            return tcs.Task;
        }
