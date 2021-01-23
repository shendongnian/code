    private void noModemChkbox_CheckedChanged(object sender, EventArgs e)
    {
        if (noModemChkbox.Checked == true)
        {
            custModemText.Enabled = false;
            pwrCbx.Enabled = false;
            e1Cbx.Enabled = false;
            e2Cbx.Enabled = false;
            e3Cbx.Enabled = false;
            e4Cbx.Enabled = false;
            dslblinkCbx.Enabled = false;
            enetCbx.Enabled = false;
            dslCbx.Enabled = false;
            inetCbx.Enabled = false;
            inetredCbx.Enabled = false;
            wlanCbx.Enabled = false;
            activityChkbox.Enabled = false;
        }
        else
        {
            custModemText.Enabled = true;
            pwrCbx.Enabled = true;
            e1Cbx.Enabled = true;
            e2Cbx.Enabled = true;
            e3Cbx.Enabled = true;
            e4Cbx.Enabled = true;
            dslblinkCbx.Enabled = true;
            enetCbx.Enabled = true;
            dslCbx.Enabled = true;
            inetCbx.Enabled = true;
            inetredCbx.Enabled = true;
            wlanCbx.Enabled = true;
            activityChkbox.Enabled = true;
        }
    }
