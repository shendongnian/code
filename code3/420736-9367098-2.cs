    private delegate void NameCallBack(string varText, int b);
    public void UpdateTextBox(string input, int t)
    {
        TextBox tb = this.Controls[String.Format("textBox{0}", t)] as TextBox;
        if (InvokeRequired)
        {
            tb.BeginInvoke(new NameCallBack(UpdateTextBox), input, t);
        }
        else
        {
            if (!String.IsNullOrEmpty(tb.Text))
            {
                tb.Text += Environment.NewLine;
            }
            tb.Text += input;
        }
    }
