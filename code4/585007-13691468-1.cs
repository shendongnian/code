    public class CompanyLayoutConverter : PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            writer.Write(HttpContext.Current.Session["CompanyName"]);
        }
    }
