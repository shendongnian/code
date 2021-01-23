    namespace NLog.LayoutRenderers
    {
        public class ThreadIdLayoutRenderer : LayoutRenderer
        {
            protected override void Append(StringBuilder builder, LogEventInfo logEvent)
            {
                builder.Append(Thread.CurrentThread.ManagedThreadId.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
