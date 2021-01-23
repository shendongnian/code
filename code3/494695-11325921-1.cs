    // View
    
    @using (Html.BeginForm()) {
      @Htmt.TextBoxFor(m => m.Name)
      @Html.TextBoxFor(m => m.Password)
    }
    
    // Constoller
    
    [HttpPost]
    public ActionResult Home(LoginModel model) 
    {
      // do auth.. and stuff
      return Redirect();
    }
