        for (int i = 0; i < amount; i++)
        {
            if (isEvil == false)
            {
                button1.Invoke(new Action(() => button1.Text = "Start"));
                break;
            }
            SendKeys.SendWait(message + "{ENTER}");
            int j = (int)numericUpDown1.Value * 10;
            Thread.Sleep(j);
        }
