    private void OnValidatingUserControlPanel(object sender, CancelEventArgs args)
    {
      if (IsTextBoxInvalid())
      {
        args.Cancel = true;
        MessageBox.Show("Invalid data in text box!!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        if (this.Parent != null)
        {
          this.GiveFocusToControlIfTabPage(this.Parent);
        }
        this.textBox.Focus();
      }
    }
    private void GiveFocusToControlIfTabPage(Control component)
    {
      if (component is TabPage)
      {
        TabPage tabPage = (TabPage)component;
        ((TabControl)tabPage.Parent).SelectedTab = tabPage;
        return;
      }
      if (component.Parent != null)
      {
        this.GiveFocusToControlIfTabPage(component.Parent);
      }
    }
