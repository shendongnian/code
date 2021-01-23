    class LoggerLogEventArgs : EventArgs
    {
        public LoggerLogEventArgs(string message)
        {
            this.message = message;
        }
        private string message;
        public string Message { get { return message; } }
	}
    class Logger
    {
        public event EventHandler<LoggerLogEventArgs> Logged;
        protected virtual void OnLogged(LoggerLogEventArgs e)
        {
            EventHandler<LoggerLogEventArgs> handler = Logged;
            if (handler != null)
                handler(this, e);
        }
        // I would change this method name to LogToEvent
        private void LogToForm(LogLevel level, string message)
        {
            if ((int)level >= Settings.Default.LogConsoleLevel)
            {
                OnLogged(new LoggerLogEventArgs(message));
            }
        }
    }
    class Form1 : Form
    {
        // Subscribe to the logger only when we are ready to display text
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            GetLog().Logged += new EventHandler<LoggerLogEventArgs>(logger_Logged);
        }
        // Unsubscribe from the logger before we are no longer ready to display text
        protected override void OnHandleDestroyed(EventArgs e)
        {
            GetLog().Logged -= new EventHandler<LoggerLogEventArgs>(logger_Logged);
            base.OnHandleDestroyed(e);
        }
        private void logger_Logged(object sender, LoggerLogEventArgs e)
        {
            if (InvokeRequired)
                BeginInvoke(new EventHandler<LoggerLogEventArgs>(logger_Logged), e);
            else
                textBox1.AppendText(e.Message);
        }
    }
