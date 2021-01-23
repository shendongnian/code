    private void OnValidatingUserControlPanel(object sender, CancelEventArgs args)
    {
      if (IsTextBoxInvalid())
      {
        args.Cancel = true;
        MessageBox.Show("Invalid data in text box!!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        this.GiveFocusToControlIfTabPage(this.Parent);
        this.textBox.Focus();
      }
    }
    private void GiveFocusToControlIfTabPage(Control ctrl)
    {
      if (ctrl== null)
      {
        return;
      }
      if (ctrl is TabPage)
      {
        TabPage tabPage = (TabPage)ctrl;
        ((TabControl)tabPage.Parent).SelectedTab = tabPage;
        return;
      }
      this.GiveFocusToControlIfTabPage(ctrl.Parent);
    }
