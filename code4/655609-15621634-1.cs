    protected void RptrItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        var myId = "";
    
        var myNameLink = e.Item.FindControl("myLink") as HyperLink;
    
        if (myNameLink != null)
        {
          var submitButton = e.Item.FindControl("btnSubmit") as Button;
          
          if (submitButton != null)
          {
            var submitButtonClientId = submitButton.ClientID;
    
            myNameLink.Attributes.Add("onclick", "onNameClick('" + submitButtonClientId + "')");
          }
        }
      }
    }//end RptrItemDataBound
