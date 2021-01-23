    private sealed class SystemLoggerPluginWrapper : ISystemLogger
    {
      private readonly SystemLog inner;
    
      public SystemLoggerPluginWrapper(SystemLog inner) {
        this.inner = inner;
      }
    
      public void log(string message)
      {
        inner.log(message);
      }
    }
