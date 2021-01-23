    public void ShowValue(int num)
    {
        if (label7.InvokeRequired)
        {
            label7.BeginInvoke((MethodInvoker)delegate { label7.Text = num.ToString(); });
        }
        else
        {
            label7.Text = num.ToString();
        }
    } 
