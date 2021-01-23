    using System.Diagnostics;
    namespace DevBindingErrors
    {
        /// <summary>
        /// Intercepts all binding error messages. Stops output appearing in VS2010 debug window.
        /// </summary>
        class BindingTraceListener: TraceListener
        {
            private string _messageType;
            public override void Write(string message)
            {
                // Always happens in 2 stages: first stage writes "System.Windows.Data Error: 40 :" or similar.
                _messageType = message;
            }
            public override void WriteLine(string message)
            {
                Debug.WriteLine(string.Format("{0}{1}", _messageType, message));
            }
        }
    }
