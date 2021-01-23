        /// <summary>
    /// A Button that includes a ThreadClick event that fires from a BackgroundWorker
    /// </summary>
    [DefaultEvent("ThreadClick")] // make sure user is directed to ThreadClick and not Click
    public class ThreadButton : Button
    {
        /* STYLE NOTE: To pick up Button styling, add the following to app.xaml
         * In the root tag
         *  xmlns:Butt="clr-namespace:ButtonThreadingWPF"
         * In 'Resources'
         *  <Style TargetType="{x:Type Butt:ThreadButton}" BasedOn="{StaticResource {x:Type Button}}" />
        */
        /// <summary>
        /// ThreadClick handler is called from BackgroundWorker thread (event does not bubble)
        /// </summary>
        public event RoutedEventHandler ThreadClick; // cannot be actual routed event, otherwise BackgroundWorker cannot call it from non-gui thread
        /// <summary>
        /// Used for doing ThreadClick work on separate thread. It is exposed in case you want to use cancellation, progress, etc in handler
        /// </summary>
        public System.ComponentModel.BackgroundWorker ButtonWorker;
        // Entry and Exit events might be handled by common routine, like a Window level controls enable/disable function
        public static readonly RoutedEvent ThreadClickEntryEvent = EventManager.RegisterRoutedEvent(
    "ThreadClickEntry", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ThreadButton));
        /// <summary>
        /// ThreadClickEntry handler is called from GUI thread on button click before BackgroundWorker is started to do ThreadClick work
        /// </summary>
        public event RoutedEventHandler ThreadClickEntry
        {
            add { AddHandler(ThreadClickEntryEvent, value); }
            remove { RemoveHandler(ThreadClickEntryEvent, value); }
        }
        public static readonly RoutedEvent ThreadClickExitEvent = EventManager.RegisterRoutedEvent(
    "ThreadClickExit", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ThreadButton));
        
        /// <summary>
        /// ThreadClickExit handler is invoked on GUI thread after BackgroundWorker finishes ThreadClick work
        /// </summary>
        public event RoutedEventHandler ThreadClickExit
        {
            add { AddHandler(ThreadClickExitEvent, value); }
            remove { RemoveHandler(ThreadClickExitEvent, value); }
        }
        private void OnThreadClick() { if (ThreadClick != null) ThreadClick(this, null); }
        private void OnEntry()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ThreadButton.ThreadClickEntryEvent);
            RaiseEvent(newEventArgs);
        }
        private void OnExit()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ThreadButton.ThreadClickExitEvent);
            RaiseEvent(newEventArgs);
        }
        public ThreadButton() : base()
        {
            ButtonWorker = new System.ComponentModel.BackgroundWorker();
            ButtonWorker.DoWork += WorkIT;
            this.Click += new RoutedEventHandler(ThreadButton_Click);
        }
        private void DefaultEntryFunc(object sender, EventArgs e) { this.IsEnabled = false; }
        private void DefaultExitFunc(object sender, EventArgs e) { this.IsEnabled = true; }
        void ThreadButton_Click(object sender, RoutedEventArgs e)
        {
            Monitor.Enter(this); // in case we are triggered multiple times by UI thread ?
            OnEntry(); // perform entry function, usually a disable button(s)
            if (!ButtonWorker.IsBusy) // If it's already going, don't bother it
            {
                ButtonWorker.RunWorkerAsync();
            }
            Monitor.Exit(this);
        }
        private void WorkIT(object sender, EventArgs e)
        {
            // Run actual event processor
            OnThreadClick();
            // Run event cleanup, usually button(s) re-enable, let UI thread take care of it
            Dispatcher.Invoke(new Action(OnExit));
        }
    } // END CLASS: ThreadButton
