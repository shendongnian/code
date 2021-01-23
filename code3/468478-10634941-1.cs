    private void form1_KeyUp(object sender, KeyEventArgs e)
    {
        //if user clicked Shift+Ins or Ctrl+V (paste from clipboard)
        if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))
        {
           /// your paste copy/paste code here
        }
    }
