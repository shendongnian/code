    if (checkBox1.Checked)
        {
            for (int i = 0; i < chkboxlst.Items.Count; i++)
            {
                chkboxlst.SetItemChecked(i, true);
            }
        }
        else
        {
            for (int i = 0; i < chkboxlst.Items.Count; i++)
            {
                chkboxlst.SetItemChecked(i, false);
            }
        }
