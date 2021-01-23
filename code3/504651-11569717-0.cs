    protected void rptPromo_ItemBound (Object sender, RepeaterItemEventArgs e)
    {
        Item i = e.Item.DataItem as Item;
        Text txtPromo = e.Item.FindControl("txtPromo") as Text;
        textPromo.Item = i;
        
        //txtPromo.Attributes.Add("txtPromo", txtPromo);
        //HTMLControl hyperLinkLookUp = e.Item.FindControl("") as 
        string s;
    }
