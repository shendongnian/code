        private void txb_TextChanged(object sender, EventArgs e)
        {
        int selStart = txb.SelectionStart;
        
        string result = txb.Text;
        
        // remove all that aren't digits
        result = Regex.Replace(result, @"[^0-9]", string.Empty);
        
        txb.Text = result;
        
        // move cursor
        if (selStart > txb.Text.Length)
            txb.Select(txb.Text.Length, 0);
        else txb.Select(selStart, 0);
        }
