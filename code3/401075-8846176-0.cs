    private void Space(object sender, EventArgs e)
    {
        if (cbRandomLine.Checked || tickCount < lbMessage.Items.Count)
        {
            SendKeys.Send(lbMessage.Items[randomLine].ToString().Substring(currentChar++, 1));
            if (currentChar == lbMessage.Items[randomLine].ToString().Length)
            {
                SendKeys.Send("{enter}");
                tmrSpace.Enabled = false;
                currentChar = 0;
            }
        }
        tmrSpace.Interval = random.Next(50, 100);
    }
