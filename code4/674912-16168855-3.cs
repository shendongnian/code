    protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
    {
        Key newKey = e.Key;
        if (e.Key == Key.A)
        {
            //handle the event and cancel the original key
            e.Handled = true;
            //get caret position
            int tbPos = this.SelectionStart;
            //insert the new text at the caret position
            this.Text = this.Text.Insert(tbPos, "b");
            newKey = Key.B;
            //replace the caret back to where it should be 
            //otherwise the insertion call above will reset the position
            this.Select(tbPos + 1, 0);
        }
            
        base.OnKeyDown(new KeyEventArgs(e.KeyboardDevice, e.InputSource, e.Timestamp, newKey));
    }
