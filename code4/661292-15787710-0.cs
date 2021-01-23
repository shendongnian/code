    if (toolStripButton2.Checked == false)
    {
        toolStripButton2.Checked = true;
        this.WindowState = FormWindowState.Maximized;
        splitContainer1.Panel2Collapsed = false;
        splitContainer1.Panel2.Show();
    }
    else 
    {
        toolStripButton2.Checked = false;
        splitContainer1.Panel2Collapsed = true;
        splitContainer1.Panel2.Hide();
    }
