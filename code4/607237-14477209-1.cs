    protected void DetailsView1_DataBound(object sender, EventArgs e)
    {
        Label l = DetailsView1.FindControl("FirstName") as Label;
        if (DetailsView1.CurrentMode == DetailsViewMode.Edit)
        {
            //obtained from your sample
            MemberProfile memberp = MemberProfile.GetuserProfile(data);
            MembershipUser myuser = Membership.GetUser()
            l.Text = memberp.fName;
        }
        else
        { 
            l.Text = "Another text or nothing";
        }
     }
