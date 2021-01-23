    if( this.NavigationContext.QueryString.ContainsKey("itemId"))
      {
          string s_itemid = this.NavigationContext.QueryString["itemId"];
          int i_itemid;
          bool result = Int32.TryParse(s_itemid, out i_itemid);
          if(result)
             //parsing success
          else
             //parsing error
    
      }
    else
       //parameter doesn't exist
