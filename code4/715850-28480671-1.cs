    private void TextBox_KeyPress(object sender, EventArgs e)
    {
       if(e.KeyCode == (char)Keys.Enter)
       {
          TextBox.DataBindings[0].WriteValue();
          dataBindingSource.ResetCurrentItem();
          TextBox.Select(TextBox.Text.Length, 0);
          e.Handled = true;
       }
    }
