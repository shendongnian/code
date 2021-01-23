    try
    {
      //statements;
    }
    catch (Exception ex)
    {
      ShowError(ex);
    }
    void ShowError(Exception ex)
    {
       //Log or Email error first
       LogOrEmailError(ex);
     
       // you can write user friendly message based on the exception provided or a generic error message.
       lblError.Visible = true;
       lblError.Text = GetUserFriendlyErrorMessage(ex); // or throw; if you are planing to handle error in global.ascx or through CustomErrors in web.config
    }
