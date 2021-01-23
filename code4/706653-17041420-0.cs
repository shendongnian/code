    public class FooAppender : AppenderSkeleton
    {
         protected override void Append(LoggingEvent loggingEvent)
         {
            // Do something with the logged data, like calling your web url
         }
    }
