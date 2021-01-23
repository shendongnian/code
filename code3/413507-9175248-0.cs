    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Server
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Starting server..");
    
                var connections = new [] {new Connection(TimeSpan.FromSeconds(1)), new Connection(TimeSpan.FromSeconds(1))};
    
                try
                {
                    foreach (var connection in connections)
                        connection.Init();
    
                    Console.WriteLine("Server running. Enter Q to quit.");
                    while (true)
                        if (Console.ReadLine().ToUpper().Trim().Equals("Q"))
                        {
                            foreach (var connection in connections)
                                connection.CancellationTokenSource.Cancel();    
                            
                            break;
                        }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    foreach (var connetion in connections)
                        connetion.Dispose();
                }
            }
        }
    
        public class Connection : IDisposable
        {
            public event EventHandler<EventArgs<Exception>> OnException;
    
            private readonly TimeSpan _reInitPause;
            private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
            private Task _task;
            private bool _lastConnectionAttemptSuccess;
    
            public Connection(TimeSpan reInitPause)
            {
                _reInitPause = reInitPause;
            }
    
            public CancellationTokenSource CancellationTokenSource
            {
                get { return _cancellationTokenSource; }
            }
    
            public void Init()
            {
                _task = new Task(OpenConnection, CancellationTokenSource.Token, TaskCreationOptions.LongRunning);
                _task.ContinueWith(OnComplete, TaskContinuationOptions.OnlyOnRanToCompletion);
                _task.ContinueWith(OnFail, TaskContinuationOptions.OnlyOnFaulted);
                _task.Start();
            }
    
            public void OpenConnection()
            {
                _lastConnectionAttemptSuccess = false;
    
                try 
                {
                    //for testing assume connection success Client.Connect(IRCHelper.SERVER, IRCHelper.PORT);
                    Debug.WriteLine("Open Connection");
                }
                catch (Exception) 
                {
                    return;
                }
    
                if (_cancellationTokenSource.IsCancellationRequested)
                    return;
    
                _lastConnectionAttemptSuccess = true;
                
                try 
                {
                    //Client.Listen();
                    //Simulate sesison lifetime
                    Thread.Sleep(1000);
                    Debug.WriteLine("Session end");
                }
                catch (Exception) {}
            }
    
            private void OnComplete(Task task)
            {
                if (_cancellationTokenSource.IsCancellationRequested)
                    return;
    
                if (_lastConnectionAttemptSuccess)  Thread.Sleep(_reInitPause);
                Init();
            }
    
            private void OnFail(Task task)
            {
                if (OnException != null)
                    OnException(this, new EventArgs<Exception>(task.Exception));
            }
    
            public void Dispose()
            {
                if (_task!=null)
                    _task.Dispose();
            }
        }
    
        public class EventArgs<T> : EventArgs
        {
            private readonly T _arg;
    
            public EventArgs(T arg)
            {
                _arg = arg;
            }
    
            public T Arg
            {
                get { return _arg; }
            }
        }
    }
