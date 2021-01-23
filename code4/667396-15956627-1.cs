    private void noModemChkbox_CheckedChanged(object sender, EventArgs e)
    {
        bool bEnabled = !noModemChkbox.Checked;
        custModemText.Enabled = bEnabled;
        pwrCbx.Enabled = bEnabled;
        e1Cbx.Enabled = bEnabled;
        e2Cbx.Enabled = bEnabled;
        e3Cbx.Enabled = bEnabled;
        e4Cbx.Enabled = bEnabled;
        dslblinkCbx.Enabled = bEnabled;
        enetCbx.Enabled = bEnabled;
        dslCbx.Enabled = bEnabled;
        inetCbx.Enabled = bEnabled;
        inetredCbx.Enabled = bEnabled;
        wlanCbx.Enabled = bEnabled;
        activityChkbox.Enabled = bEnabled;
    }
