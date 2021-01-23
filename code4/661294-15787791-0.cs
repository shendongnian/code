    public void toolStripButton2_CheckChanged(object sender, EventArgs e)
    {
        if (toolStripButton2.Checked == false)
        {
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel2.Show();
        }
        else if (toolStripButton2.Checked == true)
        {
            splitContainer1.Panel2Collapsed = true;
            splitContainer1.Panel2.Hide();
        }
    }
