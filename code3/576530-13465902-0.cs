    private void tmrDisplay_Tick(object sender, EventArgs e)
    {
        Tick();
    }
    public void Tick()
    {
        if (receivedDataList.Count > 0)
        {
            string RAW_Str = receivedDataList.Dequeue();
            //tbxConsoleOutput.AppendText(RAW_Str + Environment.NewLine);
            tbxConsoleOutput.AppendText(Parser_Selection(RAW_Str) + Environment.NewLine);
        }
    }
