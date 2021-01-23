      public virtual bool Property {
        get {          
              if(Page.IsPostBack && hiddenField != null)
                 return Page.Request.Form[hiddenField.UniqueId].ToString();
    
              return mProperty;
        }
        set {
          mProperty = value;
        }
      }
