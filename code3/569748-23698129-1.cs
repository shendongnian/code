    public static void Trace(TraceEventType eventType, string message)
    {
        if (_TraceSource.Switch.ShouldTrace(eventType))
        {
            string tracemessage = string.Format("{0}\t[{1}]\t{2}", DateTime.Now.ToString("MM/dd/yy HH:mm:ss"), eventType, message);
            foreach (TraceListener listener in _TraceSource.Listeners)
            {
                listener.WriteLine(tracemessage);
                listener.Flush();
            }
        }
    }
