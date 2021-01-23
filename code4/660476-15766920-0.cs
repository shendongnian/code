    public class LoggerScope : IDisposable {
        private bool disposed;
        public LoggerScope() {
            Logger.Start();
        }
        public void Dispose() {
            if(!disposed) {
                Logger.Finish();
                disposed = true;
            }
        }
    }
