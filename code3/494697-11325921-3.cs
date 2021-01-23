    // View
    
    @using (Html.BeginForm()) {
      @Html.TextBoxFor(m => m.Name)
      @Html.TextBoxFor(m => m.Password)
    }
    
    // Controller
    
    [HttpPost]
    public ActionResult Home(LoginModel model) 
    {
      // do auth.. and stuff
      return Redirect();
    }
