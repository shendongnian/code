    private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAll.Checked)
            {
                foreach (ListItem item in clbViruslist.Items)
                {
                    item.Selected = true;                
                }
            }
        }
