    public class EnterExitLogger : IDisposable
    {
      Logger logger;
      string name;
      public EnterExitLogger(Logger logger, string name, params object [] args)
      {
        this.logger = logger;
        this.name = name;
        this.logger.Debug("Entering {0}", this.name);
        int i = 0;
        foreach (var a in args)
        {
          this.logger.Debug("arg[{0}] = {1}", i, a);
          i++;
        }
      }
      public void Dispose()
      {
        this.Logger.Debug("Exiting {0}", this.name);
      }
    }
