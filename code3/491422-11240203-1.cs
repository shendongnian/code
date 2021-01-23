    private void cb01_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
          if(cb01.SelectedIndex != -1)
             cb01.Items.Remove(cb01.SelectedItem);
        }
    }
