    class ExtendedBackgroundWorker : BackgroundWorker
    {
        public new event ProgressChangedEventHandler ProgressChanges
        {
            add { throw new InvalidOperationException("This event cannot be added directly"); }
            remove {}
        }
        protected override void OnProgressChanged(ProgressChangedEventArgs e)
        {
            // do not call base.OnProgressChanged
        }
    }
