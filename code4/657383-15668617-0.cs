    try
    {
        if(this.Page.GetType().InvokeMember(stepGuide.SaveMethod,
            System.Reflection.BindingFlags.InvokeMethod, null, this.Page, null))
        {
            AppPageMethods.RedirectToPage(button.CommandArgument);
        }
        else
        {
            // Do something else
        }
    }
    catch (Exception ex) // Better still, use specific exceptions
    {
        // Handle exception
    }
