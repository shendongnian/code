    public class DisposableDispatchTimer : DispatchTimer, IDisposable
    {
        public void Dispose()
        {
            Stop();
        }
    }
