    public class CompanyLayoutConverter : PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
             var httpContext = HttpContext.Current;
             if (httpContext == null)
                 return;
            
             writer.Write(httpContext.Session["Company Name"]);
        }
    }
