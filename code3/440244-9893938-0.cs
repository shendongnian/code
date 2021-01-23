    TextBox tbMessages = ...;
    ImageProcessingLog log = new ImageProcessingLog();
    log.AddMessage(...);
    foreach(string msg in log.Messages)
    {
      tbMessages.Text += msg;      
    }
