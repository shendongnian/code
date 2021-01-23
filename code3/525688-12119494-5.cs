    for (int i = 0; i < fsi.Count; i++)
    {
        if (InvokeRequired)   
        {
            int iCopy = i;     // 1 instance per loop
            BeginInvoke(new Action(() => 
                textBox1.AppendText(fsi[iCopy - 1].FullName  
                + Environment.NewLine)));
        }
    }
