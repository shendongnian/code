    private void StartListeningPipes()
    {
        if(!this.isServerRunning)
        {
            return;
        }
        var pipeClientConnection = new NamedPipeServerStream(...);
        try
        {
            pipeClientConnection.BeginWaitForConnection(asyncResult =>
                {
                    // note that the body of the lambda is not part of the outer try... catch block!
                    using(var conn = (NamedPipeServerStream)asyncResult.AsyncState)
                    {
                        try
                        {
                            conn.EndWaitForConnection(asyncResult);
                        }
                        catch(...)
                        {
                            ...
                        }
                        // we have a connection established, time to wait for new ones while this thread does its business with the client
                        // this may look like a recursive call, but it is not: remember, we're in a lambda expression
                        // if this bothers you, just export the lambda into a named private method, like you did in your question
                        StartListeningPipes();
                        // do business with the client
                        conn.WaitForPipeDrain();
                        ...
                    }
                }, pipeClientConnection);
        }
        catch(...)
        {
            ...
        }
    }
