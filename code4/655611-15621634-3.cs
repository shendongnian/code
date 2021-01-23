    protected void BtnClick(object sender, EventArgs e)
    {
      var btnSelect = sender as Button;
    
      if (btnSelect == null)
      {
        return;
      }
        
      var myListItem = (RepeaterItem)btnSelect.DataItemContainer;
    
      if (myListItem != null)
      {
        var hfId = myListItem.FindControl("hfId") as HiddenField;
    
        if (hfId != null)
        {
          var intId = int.Parse(hfId.Value);
          
          Session["selectedId"] = intId;
        }//end if (hfId != null)
      }//end if (myListItem != null)
    }//end btnClick
