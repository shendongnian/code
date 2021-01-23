    public class ElmahExceptionLogger : ExceptionLogger
    {
      public override void Log(ExceptionLoggerContext context)
      {
        ...
      }
    }
    public class GenericTextExceptionHandler : ExceptionHandler
    {
      public override void Handle(ExceptionHandlerContext context)
      {
        context.Result = new InternalServerErrorTextPlainResult(
          "An unhandled exception occurred; check the log for more information.",
          Encoding.UTF8,
          context.Request);
      }
    }
