    public class LogFileEventListener : IDisposable
    {
        private bool disposed = false;
        private FileStream fileStream;
        public LogFileEventListener(string path)
        {
            //Opens a new file stream to log file
            this.fileStream = new FileStream(path, FileMode.Append, FileAccess.Write);
            GC.SuppressFinalize(this.fileStream);
        }
        /// <summary>Finalize the listener</summary>
        ~LogFileEventListener() { this.Dispose(); }
        /// <summary>Disposes the listener</summary>
        public override void Dispose()
        {
            try
            {
                if (!this.disposed)
                {
                    /* Do you stuff */
                    //Close the log file
                    if (this.fileStream != null)
                    {
                        this.fileStream.Close();
                        this.fileStream = null;
                    }
                    base.Dispose();
                }
            }
            finally
            {
                this.disposed = true;
                GC.SuppressFinalize(this);
            }
        }
    }
