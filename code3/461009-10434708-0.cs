    public sealed class ResponseReceivedEventArgs : EventArgs
    {
        public ResponseReceivedEventArgs(string id, string response)
        {
            Id = id;
            Response = response;
        }
        public string Id
        {
            private set;
            get;
        }
        public string Response
        {
            private set;
            get;
        }
    }
    public delegate void ResponseReceived(object sender, ResponseReceivedEventArgs e);
    
    public sealed class NamedPipeCommands
    {
        private readonly Queue<Tuple<string, string>> _queuedCommands = new Queue<Tuple<string,string>>();
        private string _currentId;
        private readonly Thread _sender;
        private readonly Thread _receiver;
        
        // Equivalent to receiving a "quit" on the console
        private bool _cancelRequested; 
        // To wait till a response is received for a request and THEN proceed
        private readonly AutoResetEvent _waitForResponse = new AutoResetEvent(false);
        // Lock to modify the command queue safely
        private readonly object _commandQueueLock = new object();
        
        // Raise an event when a response is received
        private void RaiseResponseReceived(string id, string message)
        {
            if (ResponseReceived != null)
                ResponseReceived(this, new ResponseReceivedEventArgs(id, message));
        }
        // Add a command to queue of outgoing commands
        // Returns the id of the enqueued command
        // So the user can relate it with the corresponding response
        public string EnqueueCommand(string command)
        {
            var resultId = Guid.NewGuid().ToString();
            lock (_commandQueueLock)
            {
                _queuedCommands.Enqueue(Tuple.Create(resultId, command));
            }
            return resultId;
        }
        // Constructor. Please pass in whatever parameters the two pipes need
        // The list below may be incomplete
        public NamedPipeCommands(string servername, string pipeName)
        {
            _sender = new Thread(syncClientServer =>
            {
                // Body of thread
                var waitForResponse = (AutoResetEvent)syncClientServer;
                using (var pipeStream = new NamedPipeClientStream(servername, pipeName, PipeDirection.Out, PipeOptions.None))
                {
                    pipeStream.Connect();
                    using (var sw = new StreamWriter(pipeStream) { AutoFlush = true })
                        // Do this till Cancel() is called
                        while (!_cancelRequested)
                        {
                            // No commands? Keep waiting
                            // This is a tight loop, perhaps a Thread.Yield or something?
                            if (_queuedCommands.Count == 0)
                                continue;
                            Tuple<string, string> _currentCommand = null;
                            
                            // We're going to modify the command queue, lock it
                            lock (_commandQueueLock)
                                // Check to see if someone else stole our command
                                // before we got here
                                if (_queuedCommands.Count > 0)
                                    _currentCommand = _queuedCommands.Dequeue();
                            // Was a command dequeued above?
                            if (_currentCommand != null)
                            {
                                _currentId = _currentCommand.Item1;
                                sw.WriteLine(_currentCommand.Item2);
                                
                                // Wait for the response to this command
                                waitForResponse.WaitOne();
                            }
                        }
                }
            });
            _receiver = new Thread(syncClientServer =>
            {
                var waitForResponse = (AutoResetEvent)syncClientServer;
                using (var pipeStream = new NamedPipeClientStream(servername, pipeName, PipeDirection.In, PipeOptions.None))
                {
                    pipeStream.Connect();
                    using (var sr = new StreamReader(pipeStream))
                        // Do this till Cancel() is called
                        // Again, this is a tight loop, perhaps a Thread.Yield or something?
                        while (!_cancelRequested)
                            // If there's anything in the stream
                            if (!sr.EndOfStream)
                            {
                                // Read it
                                var response = sr.ReadLine();
                                // Raise the event for processing
                                // Note that this event is being raised from the
                                // receiver thread and you can't access UI here
                                // You will need to Control.BeginInvoke or some such
                                RaiseResponseReceived(_currentId, response);
                                
                                // Proceed with sending subsequent commands
                                waitForResponse.Set();
                            }
                }
            });
        }
        public void Start()
        {
            _sender.Start(_waitForResponse);
            _receiver.Start(_waitForResponse);
        }
        public void Cancel()
        {
            _cancelRequested = true;
        }
        public event ResponseReceived ResponseReceived;
    }
