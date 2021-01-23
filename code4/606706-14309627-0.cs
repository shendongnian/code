    private void backgroundWorkerEncoder_DoWork(object sender, DoWorkEventArgs e)
    {
      var startTime = DateTime.Now;
      var stopwatch = Stopwatch.StartNew();
      while (serialPort.IsOpen && !backgroundWorker.CancellationPending)
      {
        if (serialPort.BytesToRead > 0)
        {
          try
          {
            var line = serialPort.ReadLine();
            var timestamp = (startTime + stopwatch.Elapsed);
            var lineString = string.Format("{0}  ----{1}", 
                                           line,
                                           timestamp.ToString("HH:mm:ss:fff"));
            // Handle formatted line string here.
          }
          catch (Exception ex)
          {
            // Handle exception here.
          }
        }
      }
