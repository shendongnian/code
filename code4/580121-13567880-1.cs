        /// <summary>
            /// Enforces single instance for an application.
            /// </summary>
            public class SingleInstance : IDisposable
            {
                #region Fields
        
                /// <summary>
                /// The synchronization context.
                /// </summary>
                private readonly SynchronizationContext synchronizationContext;
        
                /// <summary>
                /// The disposed.
                /// </summary>
                private bool disposed;
        
                /// <summary>
                /// The identifier.
                /// </summary>
                private Guid identifier = Guid.Empty;
        
                /// <summary>
                /// The mutex.
                /// </summary>
                private Mutex mutex;
        
                #endregion
        
                #region Constructors and Destructors
        
                /// <summary>
                /// Initializes a new instance of the <see cref="SingleInstance"/> class.
                /// </summary>
                /// <param name="identifier">
                /// An identifier unique to this application.
                /// </param>
                /// <param name="args">
                /// The command line arguments.
                /// </param>
                public SingleInstance(Guid identifier, IEnumerable<string> args)
                {
                    this.identifier = identifier;
        
                    bool ownsMutex;
                    this.mutex = new Mutex(true, identifier.ToString(), out ownsMutex);
        
                    this.synchronizationContext = SynchronizationContext.Current;
        
                    this.FirstInstance = ownsMutex;
        
                    if (this.FirstInstance)
                    {
                        this.ListenAsync();
                    }
                    else
                    {
                        this.NotifyFirstInstance(args);
                    }
                }
        
                /// <summary>
                /// Initializes a new instance of the <see cref="SingleInstance"/> class.
                /// </summary>
                /// <param name="identifier">
                /// An identifier unique to this application.
                /// </param>
                public SingleInstance(Guid identifier)
                    : this(identifier, null)
                {
                }
        
                #endregion
        
                #region Public Events
        
                /// <summary>
                /// Event raised when arguments are received from successive instances.
                /// </summary>
                public event EventHandler<OtherInstanceCreatedEventArgs> OtherInstanceCreated;
        
                #endregion
        
                #region Public Properties
        
                /// <summary>
                /// Gets a value indicating whether this is the first instance of this application.
                /// </summary>
                public bool FirstInstance { get; private set; }
        
                #endregion
        
                #region Implemented Interfaces
        
                #region IDisposable
        
                /// <summary>
                /// The dispose.
                /// </summary>
                public void Dispose()
                {
                    this.Dispose(true);
                    GC.SuppressFinalize(this);
                }
        
                #endregion
        
                #endregion
        
                #region Methods
        
                /// <summary>
                /// Clean up any resources being used.
                /// </summary>
                /// <param name="disposing">
                /// True if managed resources should be disposed; otherwise, false.
                /// </param>
                protected virtual void Dispose(bool disposing)
                {
                    if (this.disposed)
                    {
                        return;
                    }
        
                    if (disposing)
                    {
                        if (this.mutex != null && this.FirstInstance)
                        {
                            this.mutex.WaitOne();
                            this.mutex.ReleaseMutex();
                            this.mutex = null;
                        }
                    }
        
                    this.disposed = true;
                }
        
                /// <summary>
                /// Fires the OtherInstanceCreated event.
                /// </summary>
                /// <param name="arguments">
                /// The arguments to pass with the <see cref="OtherInstanceCreatedEventArgs"/> class.
                /// </param>
                protected virtual void OnOtherInstanceCreated(OtherInstanceCreatedEventArgs arguments)
                {
                    EventHandler<OtherInstanceCreatedEventArgs> handler = this.OtherInstanceCreated;
        
                    if (handler != null)
                    {
                        handler(this, arguments);
                    }
                }
        
                /// <summary>
                /// Listens for arguments on a named pipe.
                /// </summary>
                private void Listen()
                {
                    try
                    {
                        using (var server = new NamedPipeServerStream(this.identifier.ToString()))
                        {
                            using (var reader = new StreamReader(server))
                            {
                                server.WaitForConnection();
                                var arguments = new List<string>();
        
                                while (server.IsConnected)
                                {
                                    arguments.Add(reader.ReadLine());
                                }
        
                                this.synchronizationContext.Post(o => this.OnOtherInstanceCreated(new OtherInstanceCreatedEventArgs(arguments)), null);                        
                            }
                        }
        
                        // start listening again.
                        this.Listen();
                    }
                    catch (IOException)
                    {
                        // Pipe was broken, listen again.
                        this.Listen();
                    }          
                }
        
                /// <summary>
                /// Listens for arguments being passed from successive instances of the applicaiton.
                /// </summary>
                private void ListenAsync()
                {
                    Task.Factory.StartNew(this.Listen, TaskCreationOptions.LongRunning);
                }
        
                /// <summary>
                /// Passes the given arguments to the first running instance of the application.
                /// </summary>
                /// <param name="arguments">
                /// The arguments to pass.
                /// </param>
                private void NotifyFirstInstance(IEnumerable<string> arguments)
                {
                    try
                    {
                        using (var client = new NamedPipeClientStream(this.identifier.ToString()))
                        {
                            using (var writer = new StreamWriter(client))
                            {
                                client.Connect(200);
        
                                if (arguments != null)
                                {
                                    foreach (string argument in arguments)
                                    {
                                        writer.WriteLine(argument);
                                    }
                                }
                            }
                        }
                    }
                    catch (TimeoutException)
                    {
                        // Couldn't connect to server
                    }
                    catch (IOException)
                    {
                        // Pipe was broken
                    }
                }
        
               
    
     #endregion
        }
    /// <summary>
    /// Holds a list of arguments given to an application at startup.
    /// </summary>
    public class OtherInstanceCreatedEventArgs : EventArgs
    {
        #region Constructors and Destructors
    
        /// <summary>
        /// Initializes a new instance of the <see cref="OtherInstanceCreatedEventArgs"/> class.
        /// </summary>
        /// <param name="args">
        /// The command line arguments.
        /// </param>
        public OtherInstanceCreatedEventArgs(IEnumerable<string> args)
        {
            this.Args = args;
        }
    
        #endregion
    
        #region Public Properties
    
        /// <summary>
        /// Gets the startup arguments.
        /// </summary>
        public IEnumerable<string> Args { get; private set; }
    
        #endregion
    }
