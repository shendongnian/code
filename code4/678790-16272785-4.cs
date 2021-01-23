    public class ColoredMessageConverter : PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
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
            string logToRender = string.Format(" <p style='color:{0}'>{1}</p>", color, loggingEvent.RenderedMessage);
            //Add logToRender to file
            
            writer.Write(logToRender);
        }
    }
