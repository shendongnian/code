    void InitializeLog()
    {
      var log = new ConcurrentLogger(LogToTextBox);
      LogManager.Current.StartLogging(log);
    }
    void LogToTextBox(string line)
    {
      if (!CheckAccess())
      {
        this.Dispatcher.BeginInvoke((Action<string>)LogToTextBox,
                                    DispatcherPriority.Background, 
                                    line);
        return;
      }
      logTextBox.AppendText(line + Environment.NewLine);
    }
