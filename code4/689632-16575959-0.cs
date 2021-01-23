    private bool _hasChanges;
    
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
    	this._hasChanges = true;
    }
    
    private void form_FormClosing(object sender, FormClosingEventArgs e)
    {
    	if (this._hasChanges)
    	{
    		var dialogResult = MessageBox.Show("Save changes?", "Confirm", MessageBoxButtons.YesNoCancel);
    		switch (dialogResult)
    		{
    			case DialogResult.Yes:
    				this.Save();
    				break;
    			case DialogResult.No:
    				this._hasChanges = false;
    				break;
    		}
    		e.Cancel = this._hasChanges;
    	}
    }
    
    private void Save()
    {
    	// Save
    	this._hasChanges = false;
    }
    
    private void buttonSave_Click(object sender, EventArgs e)
    {
    	this.Save();
    }
    
    private void buttonOk_Click(object sender, EventArgs e)
    {
    	this.Close();
    }
    
    private void buttonCancel_Click(object sender, EventArgs e)
    {
    	this._hasChanges = false;
    	this.Close();
    }
