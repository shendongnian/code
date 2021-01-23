    private void Space(object sender, EventArgs e)
    {
        if (cbRandomLine.Checked || tickCount < lbMessage.Items.Count)
        {
            var index = cbRandomLine.Checked ? randomLine : tickCount;
            var item = lbMessage.Items[index ].ToString();
            SendKeys.Send(item.Substring(currentChar++, 1));
            if (currentChar == item.Length)
            {
                SendKeys.Send("{enter}");
                tmrSpace.Enabled = false;
                currentChar = 0;
            }
        }
        tmrSpace.Interval = random.Next(50, 100);
    }
