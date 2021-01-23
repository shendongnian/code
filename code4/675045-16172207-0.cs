    public delegate void InvokeDelegate();
    private void tbAux_SelectionChanged(object sender, EventArgs e)
    {
       this.BeginInvoke(new InvokeDelegate(InvokeMethod));
    }
    public void InvokeMethod()
    {
       textBox.Text = tbAux.Text;
    }
