    public partial class App : Application
    {
        public App()
        {
            // initiate it. Call it first.
            //preventSecond();
            SingleInstanceWatcher();
        }
        private const string UniqueEventName = "{GENERATE-YOUR-OWN-GUID}";
        private EventWaitHandle eventWaitHandle;
        /// <summary>prevent a second instance and signal it to bring its mainwindow to foregorund</summary>
        /// <seealso cref="https://stackoverflow.com/a/23730146/1644202"/>
        private void SingleInstanceWatcher()
        {
            // check if it is allready open.
            try
            {
                // try to open it - if another instance is running, it will exist
                this.eventWaitHandle = EventWaitHandle.OpenExisting(UniqueEventName);
                // Notify other instance so it could bring itself to foreground.
                this.eventWaitHandle.Set();
                // Terminate this instance.
                this.Shutdown();
            }
            catch
            {
                // listen to a new event
                this.eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, UniqueEventName);
            }
            
            // if this instance gets the signal to show the main window
            new Task(() =>
            {
                while (this.eventWaitHandle.WaitOne())
                {
                    Current.Dispatcher.BeginInvoke((Action)(() =>
                    {
                        // could be set or removed anytime
                        if (!Current.MainWindow.Equals(null))
                        {
                            var mw = Current.MainWindow;
                            if (mw.WindowState == WindowState.Minimized || mw.Visibility != Visibility.Visible)
                            {
                                mw.Show();
                                mw.WindowState = WindowState.Normal;
                            }
                            // According to some sources these steps gurantee that an app will be brought to foreground.
                            mw.Activate();
                            mw.Topmost = true;
                            mw.Topmost = false;
                            mw.Focus();
                        }
                    }));
                }
            })
            .Start();
        }
    }
