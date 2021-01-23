    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.F9)
      {
          tabControl1.SelectedTab = tabPage1;
          e.SuppressKeyPress = true;
      }
      else if (e.KeyCode == Keys.F10)
      {
          tabControl1.SelectedTab = tabPage2;
          e.SuppressKeyPress = true;
      }
    }
