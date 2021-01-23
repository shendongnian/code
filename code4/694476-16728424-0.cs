    private void writeToLog(string logValue, int colorIndex)
        {
            logValue = "[ " + DateTime.Now + "] " + logValue;
            if (colorIndex == 0)
            {
              string htmlCode = "<font style='color:black'>"+logValue+"</font><br/>";
              log.InnerHtml = htmlCode + log.InnerHtml;
              
            }
            else if(colorIndex == 1)
            {
                string htmlCode = "<font style='color:red'>" + logValue + "</font><br/>";
                log.InnerHtml = htmlCode + log.InnerHtml ;
            }
            else if(colorIndex == 2)
            {
                string htmlCode = "<font style='color:green'>" + logValue + "</font><br/>";
                log.InnerHtml = htmlCode + log.InnerHtml ;
            }
    
                  
            
        }
