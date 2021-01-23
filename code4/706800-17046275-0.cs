    private static async Task SaveLoop(CancellationTokenSource cancel)
    {
      string logPath = "logs\\";
      string logFile = StartTime.ToString("yyyy-MM-dd_HH-mm-ss") + ".log";
      string fullPath = Path.Combine(logPath, logFile);
      if (!Directory.Exists(logPath))
        Directory.CreateDirectory(logPath);
      using (FileStream fileStream = new FileStream(fullPath, FileMode.Append, FileAccess.Write, FileShare.Read, 8192, useAsync: true)
      using (StreamWriter writer = new StreamWriter(fileStream))
      {
        while (true)
        {
          LogMessage logMessage = await queue.ReceiveAsync(cancel);
          await writer.WriteAsync(string.Format("[{0}][{1}] ", currentMessage.Time.ToString("HH:mm:ss:fff"), currentMessage.Level.ToString()));
          await writer.WriteAsync(currentMessage.Message);
          await writer.WriteLineAsync(string.Format(" ({0} - {1})", currentMessage.Method, currentMessage.Location));
        }
      }
    }
