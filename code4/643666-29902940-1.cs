    TextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
          if (e.KeyCode == Keys.Tab)
          {
              e.Handled = true;
              SendKeys(^{TAB});
          }
    }
