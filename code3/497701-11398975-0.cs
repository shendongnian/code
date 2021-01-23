    private void FormatLinesInTextBox()
    {
        int cnt = 1;
        foreach (string line in richTextBox1.Lines)
        {
            string cntNumber = cntNumber = "CNT" + cnt;
            richTextBox1.Lines[cnt - 1] = "," + cntNumber + line.Replace(cntNumber, string.Empty);
            cnt++;
        }
    }
