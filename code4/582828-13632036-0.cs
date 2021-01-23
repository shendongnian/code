    checkEdit1.CheckedChenged += new EventHandler(checkEdit1_CheckedChanged);
    checkEdit2.CheckedChenged += new EventHandler(checkEdit2_CheckedChanged);
---
    private void checkEdit1_CheckedChanged(object sender, EventArgs e)
    {
        if(checkEdit1.Checked == checkEdit2.Checked)
          checkEdit2.Checked = !checkEdit.Checked;
    }
    private void checkEdit2_CheckedChanged(object sender, EventArgs e)
    {
        if(checkEdit1.Checked == checkEdit2.Checked)
          checkEdit2.Checked = !checkEdit.Checked;
    }
