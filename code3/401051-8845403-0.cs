    int randomness = random.Next(lbMessage.Items.Count);
    SendKeys.Send(lbMessage.Items[randomness].ToString().Substring(currentChar++, 1));
    
    if (currentChar == lbMessage.Items[randomness].ToString().Length)
    {
        SendKeys.Send("{enter}");
        tmrSpace.Enabled = false;
        currentChar = 0;
    }
