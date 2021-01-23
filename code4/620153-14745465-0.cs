    public override void SavePageState(System.Web.UI.Control pControl, object viewState)
    {
      string vsKey = String.Empty;
    
      //	Searching for the hidden field named "__vsKey"
    
      // Comment out this line 
      //System.Web.UI.HtmlControls.HtmlInputHidden ctrl = System.Web.UI.HtmlControls.HtmlInputHidden)pControl.FindControl("__vsKey");
    
     // Add this line
      string lastKey = ((Page)pControl).Request.Form["__vsKey"];
      if (lastKey == null)
      {
         //	Generate new GUID
         vsKey = Guid.NewGuid().ToString();
         //	Store in the hidden field
         
         // Remove this line its old school code
         //((Page)pControl).RegisterHiddenField("__vsKey", vsKey);
         // Add this new one
         ((Page)pControl).ClientScript.RegisterHiddenField("__vsKey", vsKey);
       }
       else
       {
         //	Use the GUID stored in the hidden field
    
         // Comment this one out
         //vsKey = ctrl.Value;
         
         // Add these two lines
         vsKey = lastKey;
         ((Page)pControl).ClientScript.RegisterHiddenField("__vsKey", lastKey);
       }
    
    // Every thing else is just as-is...
    
    }
