    if (e.CloseReason == CloseReason.UserClosing)
    {
        timer2.Stop();
        if (MessageBox.Show("Close program ?", "timers", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
        {
            e.Cancel = true;
            timer2.Start();
        }
    }
