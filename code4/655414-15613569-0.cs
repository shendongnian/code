     protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if(Page.IsPostback) {
          if(hiddenField != null)
             hiddenField.Value = Page.Request.Form[hiddenField.UniqueId].ToString();
    
          Property = Convert.ToBoolean(Page.Request.Form[hiddenField.UniqueId].ToString());    
        }
      }
