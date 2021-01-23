    public void toolStripButton2_CheckChanged(object sender, EventArgs e)
    {
        if (toolStripButton2.Checked)
        {
            splitContainer1.Panel2Collapsed = true;
            splitContainer1.Panel2.Hide();
            
        }
        else
        {
            splitContainer1.Panel2Collapsed = false;
            splitContainer1.Panel2.Show();
        }
    }
