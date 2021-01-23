    //viewModel class
    public class UserStatusViewModel {
       public string Title {get;set;}
       public bool IsLogged {get;set;
    }
    
    
    //action
    public ActionResult Index() {
      var model = new UserStatusViewModel{ Title = "Index", IsLogged = TheUser.CheckStatus()};
      return View(model);
    }
    
    //view
    
    @model UserStatusViewModel
    
    @Html.DisplayFor(m => m.Title)
    @Html.DisplayFor(m => m.IsLoggedIn)
