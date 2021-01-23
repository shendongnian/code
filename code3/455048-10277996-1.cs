    bool isInProgress = false;
    
    private void OnStartButtonClick(object sender, EventArgs args)
    {
      // avoid multiple clicks mess
      if (isInProgress) 
      {  
        return;
      }
     
      try
      {
         startButton.isEnabled = false;
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
           startButton.isEnabled = true;
       }
    }
