    void Main()
    {    
        // We'll feed this to listener
        var filePath = @"c:\temp\simulatedNetworkData.bin";
        
        // we'll use this to check our work
        var allBytes = File.ReadAllBytes(filePath);
    
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
                        .ToEnumerable()
                        .SelectMany (returnBuffer => returnBuffer)
                        .ToArray();
                    listener.Stop();
                    Console.WriteLine(
                        "Observed buffer == known buffer? {0}", 
                        allBytes.SequenceEqual(compareBuffer));                    
                });
        
        var clientTask = Task.Factory.StartNew(
            () => 
            {
                var client = new TcpClient();
                client.Connect("localhost", 11201);
                var position = 0;
                var random = new Random();
                var outStream = client.GetStream();
                while(position < allBytes.Length)
                {
                    // send some random sized chunk to listener
                    var gonnaSend = random.Next(1, (allBytes.Length - position));
                    var sendBuffer = allBytes.Skip(position).Take(gonnaSend).ToArray();
                    outStream.Write(sendBuffer, 0, sendBuffer.Length);
                    position += gonnaSend;        
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
