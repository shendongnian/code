    var rnd = random.Next(lbMessage.Items.Count);
    SendKeys.Send(lbMessage.Items[rnd].
        ToString().Substring(currentChar++, 1));
    if (currentChar == lbMessage.Items[rnd].ToString().Length)
    {
        SendKeys.Send("{enter}");
        tmrSpace.Enabled = false;
        currentChar = 0;
    }
