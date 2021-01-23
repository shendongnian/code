    protected void btnSend_OnClick(object sender, EventArgs e)
    {
    foreach (GridViewRow row in GridView.Rows)
    {
        CheckBox check = (CheckBox)row.FindControl("CheckBox1");
        CheckBox check2 = (CheckBox)row.FindControl("CheckBox2");
        if (!check.Checked  && !check2.Checked)
        {
            lblErrorCheck.Visible = true;
            break;
        }
    }
    }
