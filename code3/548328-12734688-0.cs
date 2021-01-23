    private bool PromptSave()
    {
    	if (NeedsToSave)
        {
            DialogResult saveChangesDialog = 
    		    MessageBox.Show("There are unsaved changes. Save now?", "Xml Editor",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
    
            if (saveChangesDialog == DialogResult.Yes)
            {
                Save();
    			return true;
            }
            else if (saveChangesDialog == DialogResult.Cancel)
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
