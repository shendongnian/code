    private void lipsCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (lipsCheckBox.Checked)
        {     
            DialogResult dr = MessageBox.Show("...?", "Want something else?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
 
            if(dr == DialogResult.Yes)
            {
                //
            }
            else if(dr == DialogResult.Cancel)
            {
                //
            }
        }
    }
