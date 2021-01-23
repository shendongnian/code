        private static void PrepareListeners()
        {
            Trace.Listeners.Clear();
            var logPath = "/path/to/my/file.txt";
            File.Delete(logPath);
            var textListener = new TextWriterTraceListener(logPath);
            var consoleListener = new ConsoleTraceListener(false);
            consoleListener.TraceOutputOptions = TraceOptions.DateTime;
            Trace.Listeners.Add(textListener);
            Trace.Listeners.Add(consoleListener);
            Trace.AutoFlush = true;
        }
