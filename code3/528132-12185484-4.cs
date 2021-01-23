    class MyUserControl : UserControl
    {
        private static readonly object FileOpenedKey = new Object();
        public event EventHandler<FileOpenedEventArgs> FileOpened
        {
            add { Events.AddHandler(FileOpenedKey, value); }
            remove { Events.RemoveHandler(FileOpenedKey, value); }
        }
        protected virtual void OnFileOpened(FileOpenedEventArgs e)
        {
            var handler = (EventHandler<FileOpenedEventArgs>)Events[FileOpenedKey];
            if (handler != null)
                handler(this, e);
        }
    }
