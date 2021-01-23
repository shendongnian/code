    protected void dlspec_ItemDataBound(object sender, DataListItemEventArgs e)
     {
        var ck = e.Item.FindControl("FindSimilarCheckbox") as CheckBox;
                if (ck != null)
                {
                    ck.ID = ck.Text;
                    ck.Text = "";
                    //EDIT: Karthik - Since we moved the Specifications in to user control, check if this a postback , then check to see the CheckBox state on the form while posting back
                    if(IsPostBack && Request.Form[ck.UniqueID] != null)
                    {
                        ck.Checked = true;
                    }
     }
