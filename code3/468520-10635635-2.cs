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
       lblError.Visible = true;
       // you can write user friendly message based on the exception provided or a generic error message.
       LogError(ex);
       lblError.Text = "user friendly error message"; 
    }
