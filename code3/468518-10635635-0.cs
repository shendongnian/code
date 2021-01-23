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
       lblError.Text = ex.Message; // you can write custom message to show user a friendly message in place of ex.Message here.
    }
