    public class FileOpenedEventArgs : EventArgs
    {
        private string filename;
        public FileOpenedEventArgs(string filename)
        {
            this.filename = filename;
        }
        public string Filename { get { return filename; } }
    }
    class MyUserControl : UserControl
    {
        public event EventHandler<FileOpenedEventArgs> FileOpened;
        protected virtual void OnFileOpened(FileOpenedEventArgs e)
        {
            EventHandler<FileOpenedEventArgs> handler = FileOpened;
            if (handler != null)
                handler(this, e);
        }
    }
