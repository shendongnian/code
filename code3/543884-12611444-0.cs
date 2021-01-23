    private void StartTyping(object obj)
    {
        string message = obj.ToString();
        int amount = (int)numericUpDown2.Value;
        Thread.Sleep(3000);
        for (int i = 0; i < amount; i++)
        {
            if (isEvil == false)
            {
                if (button1.InvokeRequired)
                {
                    button1.BeginInvoke( new Action(() => { button1.Text = "Start"; }) );
                }
                else
                {
                    button1.Text = "Start";
                }
                break;
            }
            SendKeys.SendWait(message + "{ENTER}");
            int j = (int)numericUpDown1.Value * 10;
            Thread.Sleep(j);
        }
        if (button1.InvokeRequired)
        {
            button1.BeginInvoke( new Action(() => { button1.Text = "Start"; }) );
        }
        else
        {
            button1.Text = "Start";
        }
    }
