    StringBuilder clntMailBody = new StringBuilder();
    
    clntMailBody.AppendLine("Some Fixed body Text")
    
    foreach(string lineItem in Invoice)
    {
        clntMailBody.AppendLine(lineItem);
    }
    
    clntMailBody.AppendFormat("Order Total {0:C}", strOrderTotal).AppendLine();
    return clntMailBody.ToString();
