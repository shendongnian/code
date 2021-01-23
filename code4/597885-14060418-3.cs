    public class MyUserController : Controller {
        private MyUserService Service = new MyUserService();
        public ActionResult Details(int id) {
            User user;
            try {
                user = Service.GetById(id);
            }
            catch(UserNotFoundException) {
                // Oops, there is no such user. Return a 404 error
                // Note that we do not care about the InvalidOperationException
                // that was thrown inside GetById
                return HttpNotFound("The user does not exist!");
            }
            // If we reach here we have a valid user
            return View(user);
         }
    }
