    bool isInProgress = false;
    
    private void OnStartButtonClick(object sender, EventArgs args)
    {
      // avoid multiple clicks mess
      // or just set startButton.isEnabled = false; whilst processing a file
      if (isInProgress) 
      {  
        return;
      }
    
      try
      {
         isInProgress = true;    
         int counter = 50;
      
         while (counter-- > 0)
         {
            var singleLine = File.ReadLine(path); 
            var message = CreateMessageFromLine(singleLine);
            transport.PostMessageToServer(message);
         }
       }
       finally
       {
           isInProgress = false;
       }
    }
