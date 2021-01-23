    if (!messageBoxShown)//<--- check messageBoxShown
    {
        if (MessageBox.Show("Blocked IP detected!\nPlease change it!", "test program",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
        {
            messageBoxShown = true; //<--- set to true
        }
        else
            DoStop();
    }
