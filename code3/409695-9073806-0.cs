    public sealed class EventProgress<T> : IProgress<T>
    {
      private readonly SynchronizationContext syncContext;
      public EventProgress()
      {
        this.syncContext = SynchronizationContext.Current ?? new SynchronizationContext();
      }
      public event Action<T> Progress;
      void IProgress<T>.Report(T value)
      {
        this.syncContext.Post(_ =>
        {
          if (this.Progress != null)
            this.Progress(value);
        }, null);
      }
    }
