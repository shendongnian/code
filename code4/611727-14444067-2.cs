    void Main()
    {    
        // We'll feed this to listener
        var message = "Yo mamma said you like messages like this";
        
        var listenerTask = Task
            .Factory
            .StartNew(() => 
                {
                    var bufferSize = 1024;
                    var localhost = new IPAddress(new byte[]{127,0,0,1});
                    var listener = new TcpListener(localhost, 11201);
                    listener.Start();
                    var incomingClient = listener.AcceptTcpClient();
                    var clientStream = incomingClient.GetStream();
                    // our buffered reader
                    var observer = clientStream.ReadObservable(bufferSize);
                    var compareBuffer = observer
                        // Take while we're getting data and the client
                        // is still connected
                        .TakeWhile(returnBuffer => returnBuffer.Length > 0 && 
                            incomingClient.Connected)
                        // In between read blocks, respond back to the client
                        // No need for fanciness here, just normal async writeback
                        .Do(returnBuffer => clientStream.BeginWrite(
                                 returnBuffer, 
                                 0, 
                                 returnBuffer.Length, 
                                 ar => clientStream.EndWrite(ar), 
                                 null))
                        .ToEnumerable()
                        .SelectMany (returnBuffer => returnBuffer)
                        .ToArray();
                    listener.Stop();
                    Console.WriteLine(
                         "Listener thinks it was told... {0}", 
                         Encoding.ASCII.GetString(compareBuffer));
                });
        
        var clientTask = Task.Factory.StartNew(
            () => 
            {
                var client = new TcpClient();
                client.Connect("localhost", 11201);
                var random = new Random();
                var outStream = client.GetStream();
                var bytesToSend = Encoding.ASCII.GetBytes(message);
                foreach(byte toSend in bytesToSend)
                {
                    // send a character over
                    outStream.WriteByte(toSend);
    
                    // Listener should parrot us...
                    int goOn = outStream.ReadByte();
                    if(goOn != toSend)
                    {
                        Console.WriteLine(
                            "Huh. Listener echoed wrong. I said: {0}, they said {1}", 
                             toSend, 
                             goOn);
                        break;
                    }
                    Console.WriteLine("I said: {0}, they said {1}", toSend, goOn);
                    
                    // Take a little nap (simulate latency, etc)
                    Thread.Sleep(random.Next(200));
                }
                client.Close();
            });
            
        Task.WaitAll(listenerTask, clientTask);
    }
    
    
    public static class Ext
    {        
        public static IObservable<byte[]> ReadObservable(this Stream stream, int bufferSize)
        {        
            // to hold read data
            var buffer = new byte[bufferSize];
            // Step 1: async signature => observable factory
            var asyncRead = Observable.FromAsyncPattern<byte[], int, int, int>(
                stream.BeginRead, 
                stream.EndRead);
            return Observable.While(
                // while there is data to be read
                () => stream.CanRead, 
                // iteratively invoke the observable factory, which will
                // "recreate" it such that it will start from the current
                // stream position - hence "0" for offset
                Observable.Defer(() => asyncRead(buffer, 0, bufferSize))
                    .Select(readBytes => buffer.Take(readBytes).ToArray()));
        }
    }
