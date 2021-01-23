    protected void Button3_Click(object sender, EventArgs e) 
    {
        MailMessage mailMessage=new MailMessage(); 
        foreach(GridViewRow gr in GridView1.Rows) 
        { 
            CheckBox cb = (CheckBox)gr.FindControl("chkItem"); 
            if(cb.Checked) 
            { 
                //sb.Append(GridView1.DataKeys[gr.RowIndex]["Email"].ToString()); 
                //sb.Append(","); 
                //SETUP THE EMAIL ADDRESSES TO WHICH YOU WANT TO SEND EMAIL
                mailMessage.To.Add(new MailAddress(
                         GridView1.DataKeys[gr.RowIndex]["Email"].ToString()));
            } 
        } 
