    protected void rptPromo_ItemBound (Object sender, RepeaterItemEventArgs e)
    {
        Item i = e.Item.DataItem as Item;
        Sitecore.Web.UI.WebControls.Text txtPromo = e.Item.FindControl("txtPromo") as Sitecore.Web.UI.WebControls.Text;
        txtPromo.Item = i;
        
        //txtPromo.Attributes.Add("txtPromo", txtPromo);
        //HTMLControl hyperLinkLookUp = e.Item.FindControl("") as 
        string s;
    }
