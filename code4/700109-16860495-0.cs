    //In your model add the ReturnUrl Property
    public class AuthenticatModel
    {
         public string Account {get; set;}
         public string SocialSecurityNumber {get;set;}
         public string ReturnUrl {get;set;}
    }
    
    ModelState.AddModelError("Authenticated", authenticationError);
    //Set the return URL property before returning the view
    model.ReturnUrl = returnUrl;
    return View(model);
    @* add the return URL as a hidden field to your view so it can be posted back *@
    @Html.HiddenFor(model => model.ReturnUrl)
