    private void btnControl_Click(object sender, EventArgs e)
    {
        foreach(var checkBoxChecked in chkBoxes.Where(x => x.Checked))
        {
            div.Controls.Add(new WebControl()) // or whatever the heck else it is you need.
        }
    }
