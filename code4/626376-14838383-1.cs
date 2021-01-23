    protected void rptNames_OnItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
       if ((e.ItemType==ListItemType.Item) || (e.ItemType==ListItemType.AlternatingItem)) {
          string name = e.Item.DataItem("Name").ToString();
          //check if the first letter of the current name is new. If it is new, we print out the header
          if(!name.StartsWith(this._AlphaHeaderCurrent)) {
             this._AlphaHeaderCurrent = name.SubString(1);                               
             ((Panel)e.ItemFindControl("pnlAlphaHeader")).Visible = true;
             ((Label)e.Item.FindControl("lblAlphaHeader")).Text = the._AlphaHeader;
          }
          ((Label)e.Item.FindControl("lblName")).Text = name;          
       }
    }
