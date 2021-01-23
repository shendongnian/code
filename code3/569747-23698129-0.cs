        public static void Trace(TraceEventType eventType, string message)
        {
            if (_TraceSource.Switch.ShouldTrace(eventType))
            {
                foreach (TraceListener listener in _TraceSource.Listeners)
                {
                    listener.WriteLine(string.Format("{0}\t[{1}]\t{2}", DateTime.Now.ToString("MM/dd/yy HH:mm:ss"), eventType, message));
                    listener.Flush();
                }
            }
        }
