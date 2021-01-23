    private void InputExpressionRchTxt_KeyDown(object sender, KeyEventArgs e)
    {
        bool ctrlV = e.Modifiers == Keys.Control && e.KeyCode == Keys.V;
        bool shiftIns = e.Modifiers == Keys.Shift && e.KeyCode == Keys.Insert;
        if (ctrlV || shiftIns)
            if (Clipboard.ContainsImage())
                e.Handled = true;
    }
