    private delegate void NameCallBack(string varText, int b);
    public void UpdateTextBox(string input, int t)
    {
        //TextBox tb = FindControl ("textBox" + t.ToString()) as TextBox;
        TextBox tb = this.Controls[String.Format("textBox{0}", t)] as TextBox;
        if (InvokeRequired)
        {
            tb.BeginInvoke(new NameCallBack(UpdateTextBox), input, t);
        }
        else
        {
            tb.Text = tb.Text + Environment.NewLine + input;
        }
    }
