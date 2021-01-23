    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      IFormActions se = this.ActiveControl as IFormActions;
      if ((se != null) && se.AskBeforeClosing()) {
        if (MessageBox.Show("Do you want to save before exit?", "Closing", MessageBoxButtons.YesNo,  MessageBoxIcon.Information) == DialogResult.Yes) {
          se.SaveData();
          MessageBox.Show("Saved", "Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      }
    }
