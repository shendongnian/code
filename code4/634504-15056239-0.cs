    // Master Page
    protected void BtnSearch_OnClick(object sender, EventArgs e)
    {
       // remove that lines
       // MySession.Current.ItemName = TxtItem.Text.Trim();
       // Server.Transfer("~/default.aspx");
    }
    
    // Content Page
    protected void Page_Init(object sender, EventArgs e)
    {
       // direct add here your variable on session
       var vSearchText = TxtItem.Text.Trim();
       if(!string.IsNullOrEmpty(vSearchText))
           MySession.Current.ItemName = vSearchText ;
       // ------------ rest of your code ---------------    
       // If they're actively viewing an item, display its info
       bool HasActiveItem = string.IsNullOrEmpty(MySession.Current.ItemName) ? false : true;
       if (HasActiveItem)
       {
          // Makes one DB call to get all info; 
          // Binds all that info to GridViews/tables/labels on the page
          BindAllDataControls(MySession.Current.ItemName);
    
          // Display
          DisplayItemDetails();
       }
    }
