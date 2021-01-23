    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        this.Invoke(new Action<TextBox, int, int>(UpdateTextboxSelection), new object[] { textBox1, (int)e.UserState, 1 });
    }
    
    private void UpdateTextboxSelection(TextBox t, int start, int length)
    {
        t.SelectionStart = start;
        t.SelectionLength = length;
        t.Focus(); // to make sure the box is in focus so that you see the selection
    }
