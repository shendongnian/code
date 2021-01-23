    private void ChkBxSnmPv3OnCheckedChanged(object sender, EventArgs eventArgs)
    {
        snmpSettingsErrorProvider.Clear();
        // cast the sender once only
        CheckBox cb = sender as CheckBox;
        if (null == cb) return;
        SetEnabled(grpBxSNMPv3, cb.Checked, new[] { cb });
    }
    private void SetEnabled(Control parent, bool isEnabled, Control[] exludeControls)
    {
        if (null == parent) return;
        foreach (Control control in parent.Controls)
        {
            if (!excludeControls.Contains(control))
                control.Enabled = isEnabled;
        }
    }
