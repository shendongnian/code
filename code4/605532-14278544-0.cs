    private readonly object _looker = new object();
    
    private void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                lock(_locker)
                {
                    sw.WriteLine(outLine.Data);
                }
            }
        }
