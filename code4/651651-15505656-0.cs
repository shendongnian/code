    protected void rptLastPromotion_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
                    HtmlAnchor aView = (HtmlAnchor)e.Item.FindControl("aDescription");
                    Label lbldescriptionlink = (Label)e.Item.FindControl("lblDescription");
                    Label lbldescriptionNoLink = (Label)e.Item.FindControl("lblDescription2");
                    HiddenField hfIsNewTab = (HiddenField)e.Item.FindControl("hfNewTab");
    
                        if (!String.IsNullOrEmpty(aView.HRef))
                        {
                            lbldescriptionlink.Visible = true;
                            lbldescriptionNoLink.Visible = false;
                            if (Convert.ToBoolean(hfIsNewTab.Value) == true)
                            {
                                aView.Target = "_blank";
                            }
                        }
                        else
                        {
                            lbldescriptionlink.Visible = false;
                            lbldescriptionNoLink.Visible = true;
                        }
    
                  }
                }
