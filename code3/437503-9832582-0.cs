    [Authorize]
    public class AdminController : Controller {
      public ActionResult ActionRequiringRoleFoo() {
        if( !User.IsInRole( "foo" ) ) return RedirectToAction( "InsufficientPrivileges" );
        return View();
      }
