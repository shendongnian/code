    public static class myClass
    {
      
        [XmlRoot("Exception"), System.Xml.Serialization.XmlType("Exception")]
        public class exception
        {
            public exception()
            {
                ExceptionType = "";
                appDomain = "";
                Message = "";
                StackTrace = "";
                ExceptionString = "";
                InnerException = null;
                HelpLink = "";
                TargetSite = "";
                Source = "";
            }
            internal exception(Exception ex)
            {
                ExceptionType = ex.GetType().ToString();
                appDomain = AppDomain.CurrentDomain.FriendlyName;
                Message = ex.Message;
                StackTrace = ex.StackTrace == null ? " - " : ex.StackTrace.ToString();
                HelpLink = ex.HelpLink == null ? " - " : ex.HelpLink.ToString();
                TargetSite = ex.TargetSite == null ? " - " : ex.TargetSite.ToString();
                Source = ex.Source == null ? " - " : ex.Source.ToString();
                ExceptionString = ex.ToString();
                if (ex.InnerException != null)
                    InnerException = new exception(ex.InnerException);
            }
            [XmlElement("ExceptionType")]
            public string ExceptionType { get; set; }
            [XmlElement("AppDomain")]
            public string appDomain { get; set; }
            [XmlElement("Message")]
            public string Message { get; set; }
            [XmlElement("StackTrace")]
            public string StackTrace { get; set; }
            [XmlElement("ExceptionString")]
            public string ExceptionString { get; set; }
            [XmlElement("HelpLink")]
            public string HelpLink { get; set; }
            [XmlElement("TargetSite")]
            public string TargetSite { get; set; }
            [XmlElement("Source")]
            public string Source { get; set; }
            [XmlElement("InnerException")]
            public exception InnerException { get; set; }
        }
        private static System.Diagnostics.TraceSource TraceLogger { get; set; }
        static myClass()
        {
            var xml = new System.Diagnostics.XmlWriterTraceListener(System.IO.Directory.GetCurrentDirectory() + "\\ApplicationTrace.svclog");
            xml.TraceOutputOptions = System.Diagnostics.TraceOptions.Callstack | System.Diagnostics.TraceOptions.DateTime | System.Diagnostics.TraceOptions.LogicalOperationStack | System.Diagnostics.TraceOptions.ProcessId | System.Diagnostics.TraceOptions.ThreadId | System.Diagnostics.TraceOptions.Timestamp;
            TraceLogger = new System.Diagnostics.TraceSource("TraceLogger");
            TraceLogger.Switch.Level = System.Diagnostics.SourceLevels.All;
            TraceLogger.Listeners.Add(xml);
            TraceLogger.Flush();
            TraceLogger.Close();
        }
        private static void WriteException(Exception ex)
        {
            using (var writer = new StringWriter())
            {
                exception ee = new exception(ex);
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(ee.GetType());
                x.Serialize(writer, ee);
                var xmlEncodedList = writer.GetStringBuilder().ToString();
                XmlTextReader myXml = new XmlTextReader(new StringReader(xmlEncodedList));
                XPathDocument xDoc = new XPathDocument(myXml);
                XPathNavigator myNav = xDoc.CreateNavigator();
                TraceLogger.TraceData(System.Diagnostics.TraceEventType.Error, 0, myNav);
                TraceLogger.Flush();
            }
        }
        public static void HandleExceptions(Exception ex)
        {
           //do some thing then log
                WriteException(ex);
        }
    }
