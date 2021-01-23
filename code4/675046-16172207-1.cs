    private delegate void InvokeDelegate();
    private void tbAux_SelectionChanged(object sender, EventArgs e)
    {
       this.BeginInvoke(new InvokeDelegate(HandleSelection));
    }
    private void HandleSelection()
    {
       textBox.Text = tbAux.Text;
    }
