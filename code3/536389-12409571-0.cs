    private void AdminFrame_FormClosing(object sender, FormClosingEventArgs e)
    {
        var res = MessageBox.Show(this, "You really want to quit?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        if (res != DialogResult.Yes)
        {
          e.Cancel = true;
          return;
        }
    }
