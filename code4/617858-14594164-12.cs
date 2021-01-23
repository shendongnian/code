    List<Links> links = new List<Links>();
    foreach (RepeaterItem item in rptLinks.Items)
    {
       //find all your controls and their values
       string details = ((TextBox)e.Item.Findcontrol("txtDetails")).Text;
       //do this for each control
       
       //use object initialization here
       links.Add(new Link {Details = details, [PROPERTY NAME] = [REPEATER ITEM VALUE], etc});
    }
