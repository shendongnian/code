    bool allUnchecked = true;
    foreach (GridViewRow row in GridView1.Rows)
    {
        CheckBox cb = (CheckBox)row.FindControl("CheckBox1");
        if (cb != null && cb.Checked)
        {
            /* your existing code here */
            allUnchecked = false;
        }
        /* no else branch here */
        for (int i = 0; i < rowsToDelete.Count; i++)
        {
            dt.Rows.Remove(rowsToDelete[i]);
        }
    }
    lblError.Visible = allUnchecked;
