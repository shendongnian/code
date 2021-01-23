    private void ExitToolStripMenuItemClick(object sender, EventArgs e)
    {
      if (DoSaveOnExit())
        Save();
      else
        return;
    }  
    private void FrmEditorFormClosing(object sender, FormClosingEventArgs e)
    {
       if (DoSaveOnExit())
        Save();
       else
        e.Cancel = true;             
    }
    private bool DoSaveOnExit()
    {
      if (NeedsToSave)
      {
         DialogResult saveChangesDialog = MessageBox.Show("T", "Xml Editor",
         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        if (saveChangesDialog == DialogResult.Yes)
        {
            return true;
        }
        else if (saveChangesDialog == DialogResult.Cancel)
        {
            return false;
        }
    }
