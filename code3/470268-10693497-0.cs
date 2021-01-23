    private void ChkBxSnmPv3OnCheckedChanged(object sender, EventArgs eventArgs)
    {
        snmpSettingsErrorProvider.Clear();
        // cast the sender once only
        CheckBox cb = sender as CheckBox;
        if (null == cb) return;
        foreach (Control control in grpBxSNMPv3.Controls)
        {
            if (control != sender)
                control.Enabled = cb.Checked;
        }
    }
