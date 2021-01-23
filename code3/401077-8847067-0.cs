    private void Interval(object sender, EventArgs e)
    {
        if (cbPause.Checked) 
        {
           randomLine = random.Next(lbMessage.Items.Count); 
           tmrSpace.Enabled = true;
           if (whenStart)
               tickCount++;
           else whenStart = true;
        }
        else
        {
            if (cbRandomLine.Checked)
            {
                SendKeys.Send(lbMessage.Items[random.Next(lbMessage.Items.Count)].ToString() + "{enter}");
            }
            else
            {
                if (tickCount < lbMessage.Items.Count)
                {
                    SendKeys.Send(lbMessage.Items[tickCount].ToString() + "{enter}");
                    tickCount++;
                }
            }
        }
        if (tickCount == lbMessage.Items.Count) tickCount = 0;
        SetInterval();
    }
