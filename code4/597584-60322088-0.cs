    private void cbCheckAllCHECKBOXs_CheckedChanged(objects sender, EventArgs e)
    {
        if (cbCheeckAllCHECKBOXs.Checked)
        {
            for (int i = 0; i < tlpCHECKBOXsControlPanel.RowCount; i++)
            {
                ((System.Windows.Forms.CheckBox)(tlpCHECKBOXsControlPanel.GetControlFromPosition(3, i))).Checked = true;
            }
        }
    }
