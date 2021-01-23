        string new_text = txtnew.Text;
        string old_text = txtold.Text;
        var found = 0;
        foreach (var c_old in old_text)
        {
            if (new_text.IndexOf(c_old) != -1)
            {
              found++;
            }
        }
        //percentage of characters in the old text that also appear in the new text
        double percentage = (100d * found) / old_text.Length;    
        MessageBox.Show(percentage.ToString());
