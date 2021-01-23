    public class BindingErrorListener : TraceListener
    {
        private Action<string> logAction;
        public static void Listen(Action<string> logAction)
        {
            PresentationTraceSources.DataBindingSource.Listeners
                .Add(new BindingErrorListener() { logAction = logAction });
        }
        public override void Write(string message) { }
        public override void WriteLine(string message)
        {
            logAction(message);
        }
    }
