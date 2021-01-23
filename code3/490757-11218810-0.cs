    private void btnClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }
    private void frmData_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (DataDirty)
        {
            if (MessageBox.Show("You have unsaved data. Do you want to save the changes and exit the form?",
                                "Data Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                Program.fInput = new frmInputFiles(gtId, gName);
                Program.fInput.Show();
            }
            else
                e.Cancel = true;
        }
        else
        {
            Program.fInput = new frmInputFiles(gPlantId, gPlantName);
            Program.fInput.Show();
        }
    }
