    public override void WriteLine(string value)
    {
        if (InvokeRequired)
        {
            Invoke(() => WriteLine(value));
            return;
        }
        
        base.WriteLine(DateTime.Now.ToString(value));
        textBoxOutput.AppendText(value.ToString() + Environment.NewLine);
        writer.Write(value);
    }
