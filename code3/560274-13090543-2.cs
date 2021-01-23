    if (Page.IsCallback)
    {
    	System.Reflection.MethodInfo saveAllStateMethod = typeof(System.Web.UI.Page).GetMethod("SaveAllState", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
    	saveAllStateMethod.Invoke(Page, null);
    }
