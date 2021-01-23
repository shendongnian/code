    try{
      this.Page.GetType().InvokeMember(stepGuide.SaveMethod, System.Reflection.BindingFlags.InvokeMethod, null, this.Page, null);
      AppPageMethods.RedirectToPage(button.CommandArgument);
    }
    catch(Exception e)
    {
       //Do something else than redirect here
    }
