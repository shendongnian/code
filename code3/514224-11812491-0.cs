    {
        if (e.KeyData == Keys.Enter)
        { 
			e.SuppressKeyPress = true;
          if ((input.Text.ToUpper() == "FURNACE" || input.Text.ToUpper() == "COAL") && count == 3)
                {
                    end3();
                }
                else
                {
                    MessageBox.Show("Unknown key");
                }
        }
    }
