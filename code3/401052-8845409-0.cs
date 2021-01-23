    int index = random.Next(lbMessage.Items.Count);
    string value = lbMessage.Items[index].ToString(); 
    
    SendKeys.Send(value.Substring(currentChar++, 1));
    
    if (currentChar == value.Length)
    {
        SendKeys.Send("{enter}");
        tmrSpace.Enabled = false;
        currentChar = 0;
    }
