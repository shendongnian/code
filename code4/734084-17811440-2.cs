        public class FocusNotifierEventArgs : EventArgs
        {
            public object OldObject { get; set; }
            public object NewObject { get; set; }
        }
    
        public class FocusNotifier : IDisposable
        {
            public event EventHandler<FocusNotifierEventArgs> OnFocusChanged;
            bool isDisposed;
            Thread focusWatcher;
            Dispatcher dispatcher;
            DependencyObject inputScope;
            int tickInterval;
    
            public FocusNotifier(DependencyObject inputScope, int tickInterval = 10)
            {
                this.dispatcher = inputScope.Dispatcher;
                this.inputScope = inputScope;
                this.tickInterval = tickInterval;
                focusWatcher = new Thread(new ThreadStart(FocusWatcherLoop))
                {
                    Priority = ThreadPriority.BelowNormal,
                    Name = "FocusWatcher"
                };
                focusWatcher.Start();
            }
    
            IInputElement getCurrentFocus()
            {
                IInputElement results = null;
                Monitor.Enter(focusWatcher);
                dispatcher.BeginInvoke(new Action(() =>
                    {
                        Monitor.Enter(focusWatcher);
                        results = FocusManager.GetFocusedElement(inputScope);
                        Monitor.Pulse(focusWatcher);
                        Monitor.Exit(focusWatcher);
                    }));
                Monitor.Wait(focusWatcher);
                Monitor.Exit(focusWatcher);
                return results;
            }
    
            void FocusWatcherLoop()
            {
                object oldObject = null;
                while (!isDisposed)
                {
                    var currentFocus = getCurrentFocus();
                    if (currentFocus != null)
                    {
                         if (OnFocusChanged != null)
                            dispatcher.BeginInvoke(OnFocusChanged, new object[]{ this,  new FocusNotifierEventArgs()
                            {
                                OldObject = oldObject,
                                NewObject = currentFocus
                            }});
                        oldObject = currentFocus;
                        }
                    }
                    Thread.Sleep(tickInterval);
                }
            }
    
            public void Dispose()
            {
                if (!isDisposed)
                {
                    isDisposed = true;
                }
            }
        }
    
      
