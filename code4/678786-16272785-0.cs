    public class ColoredFileAppender : AppenderSkeleton
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
            string color = "";
            switch (loggingEvent.Level.Name)
            {
                case "DEBUG":
                    color = "green";
                    break;
                case "WARN":
                case "INFO":
                    color = "white";
                    break;
                case "ERROR":
                    color = "pink";
                    break;
                case "FATAL":
                    color = "red";
                    break;
            }
            string log = RenderLoggingEvent(loggingEvent);
            string logToRender = string.Format(" <p style='color:{0}'>{1}</p>", color, log);
            //Add logToRender to file
        }
    }
