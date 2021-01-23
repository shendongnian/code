    public class Foo
    {
      private readonly ILogger logger;
      public Foo(ILogger logger)
      {
        if (logger == null)
          throw new ArgumentNullException("logger");
        this.logger = logger;
      }
      public void Func()
      {
        try
        {
          // do something
        }
        catch (Exception ex)
        {
          // call the provided logger dependency
          this.logger.WriteError(ex);
          // not the static singleton property
          Logger.Instance.WriteError(ex);
        }
      }
    }
