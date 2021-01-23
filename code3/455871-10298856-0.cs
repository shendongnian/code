    protected void repeaterPatientList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
    
            Label lblbirthDate = (Label)e.Item.FindControl("lblPatientsBirthDate");
            if(lblbirthDate!= null)
            {
               DateTime d = DateTime.Parse(lblbirthDate.Text);
               lblbirthDate.Text = d.ToString("dd-MMM-yyyy");
            }
        }
