    protected void btnGetData_Click(object sender, EventArgs e)
    {
       headlines = masg.Split('*');
       rptCheckboxes.DataSource = headlines;
       rptCheckboxes.DataBind();
    }     
    protected void btnShow_Click(object sender, EventArgs e)
    {
       string newmsg = new string();
       foreach(RepeaterItem currentControl in rptCheckboxes.Items)
       {
           CheckBox currentCheckBox = currentControl.FindControl("cbxMessage");
           if(currentCheckBox != null && currentCheckBox.Checked)
           {
                 newmsg += cb[i].Text + '*';
           }
       }
       //This is a bad idea here, but we'll keep it for now
       Response.Write("<BR><BR><BR>" + newmsg);
    }
