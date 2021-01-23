        int threadId = Thread.CurrentThread.ManagedThreadId;
        bool sentinel = true;
        while (sentinel)
        {
            NamedPipeServerStream pipeServer =
                new NamedPipeServerStream("shapspipe", PipeDirection.InOut, 1);
            // Wait for a client to connect
            pipeServer.WaitForConnection();
            Console.WriteLine("Client connected on thread[{0}].", threadId);
            try
            {
                // Read the request from the client. Once the client has
                // written to the pipe its security token will be available.
                StreamString ss = new StreamString(pipeServer);
                // Verify our identity to the connected client using a
                // string that the client anticipates.
                ss.WriteString("I am the one true server!");
                string message = ss.ReadString();
                Console.WriteLine("received from client: " + message);
                ss.WriteString("echo from server: " + message);
                Console.WriteLine("Received from client: {0} on thread[{1}] as user: {2}.",
                    message, threadId, pipeServer.GetImpersonationUserName());
            }
            // Catch the IOException that is raised if the pipe is broken
            // or disconnected.
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
            pipeServer.WaitForPipeDrain();
            pipeServer.Close();
        }
