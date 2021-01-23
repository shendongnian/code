    public class UserController
    {
       ctor(IUserRepository userRepo, IUserDetailModelMapper mapper){...}
    
       public ActionResult Details()
       {
          var model = _mapper.Map(_userRepo.GetPerson());
          return View(model);
       }
    }
