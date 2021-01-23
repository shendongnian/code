    private void rdMeter_CheckedChanged(Object sender, EventArgs e)
    {
        grpMeter.Visible = rdMeter.Checked;
        grpTag.Visible = !rdMeter.Checked;
    }
    
    private void rdTag_CheckedChanged(Object sender, EventArgs e)
    {
        grpTag.Visible = rdTag.Checked;
        grpMeter.Visible = !rdTag.Checked;
    }
