    protected void rptQuestionnaire_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
           Repeater currentRepeater = (Repeater)sender;
           // Note that you might only need one ".Parent" here.  Or you might need
           // more, depends on your actual markup.
           var data = ((RepeaterItem)e.Item.Parent.Parent).DataItem as PatientReferral;
           // Now you have access to data.Answers from the parent Repeater
        }
    }
