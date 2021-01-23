        private void frmPlant_FormClosing(object sender, FormClosingEventArgs e)
        {
        if (DataDirty)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to exit", "Data Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                 this.Close();
                 Application.Exit();
            }
            else
                e.Cancel = true;
        }
        else
             Application.Exit();
        }
