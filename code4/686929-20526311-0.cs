    /// <summary>
    /// Testing Net Sockets..
    /// </summary>
    /// <author>Jeff Hansen</author>
    public class SocketTests
    {
        /// <summary>
        /// The local endpoint for the server. There's no place like 127.0.0.1
        /// </summary>
        private IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1337);
        /// <summary>
        /// Tests that a call to .Receive will return all unread data.
        /// </summary>
        /// <author>Jeff Hansen</author>
        [Fact]
        public void ReceiveWillReadAllUnreadData()
        {
            // We expect to receive double data.
            const string expected = "HELLOHELLO";
            const string dataToSend = "HELLO";
            // Start the server in a background task.
            // We do this because the receive call is blocking.
            var bgTask = Task.Factory.StartNew(() =>
            {
                var server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    // Bind to the endpoint and start listening.
                    server.Bind(endpoint);
                    server.Listen(10); // 10 is max allowed connections in queue (I think)
                    // Client connected, receive data
                    var connectingClient = server.Accept();
                    // So low-level we even get to allocate room for the data buffer manually.
                    var buf = new byte[1024];
                    // Hangs until data flows.
                    var sz = connectingClient.Receive(buf); // This is the size of the data we just received.
                    var data = Encoding.ASCII.GetString(buf, 0, sz); // We use the size to only grab what we need from the buffer.
                    Console.WriteLine("Data received: {0}", data);
                    // This is going to pass because we sent the data twice,
                    // and the call to Receive would not be able to complete in time
                    // for it to clear before more data becomes available.
                    Assert.Equal(expected, data);
                    /*
                     * BAM! Theory proven. We seriously had issues 
                     * because we didn't understand how it worked. This is why you usually end
                     * your transmission with a newline.
                     */
                    Console.WriteLine("Server closing");
                    server.Close();
                }
                catch (Exception e)
                {
                    // Make sure we close the server.
                    server.Close();
                    throw;
                }
            });
            // Create a client socket and connect it to the server.
            // The server thread should have started it up by now.
            var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(endpoint);
            // Get the bytes of our string
            var buffer = Encoding.ASCII.GetBytes(dataToSend);
            // Send it out twice. This happens faster than the server will process it,
            // so the data is stacking up. You would THINK that .Receive would
            // simply return the first data sent to it, and the next time .Receive is called
            // return the next. But that's not how it works, apparently.
            client.Send(buffer);
            client.Send(buffer);
            // Wait for the server to finish whatever it's doing.
            try
            {
                // We give it 3000ms to complete.
                bgTask.Wait();
            }
            catch (AggregateException ag)
            {
                // Throw any esceptions that were thrown in the background thread.
                ag.Handle(ex => { throw ex; });
            }
            
            // Close the client socket.
            client.Close();
        }
    }
