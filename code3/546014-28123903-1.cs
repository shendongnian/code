    private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBoxAll.Checked)
            for (int i=0; i <= clbViruslist.Items.Count; i++)
                clbViruslist.SetItemChecked(i, true);
        else
            for (int i=0; i <= clbViruslist.Items.Count; i++)
                clbViruslist.SetItemChecked(i, false);
    }
