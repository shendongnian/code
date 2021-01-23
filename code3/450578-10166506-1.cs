    public static T FindControl<T>(System.Web.UI.Control Control) where T : class
    {
         T found = default(T);
    
         if (Control != null && Control.Parent != null)
         {
    		if(Control.Parent is T)
    			found = Control.Parent;
    		else
    			found = FindControl<T>(Control.Parent);
         }
    
         return found;
    }
