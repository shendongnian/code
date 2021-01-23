    public class HomeController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MyUser user)
        {
            // break point next line works
            if (ModelState.IsValid)
                try
                {
                    //db.Users.Add(user);
                    //db.SaveChanges();
                    return RedirectToAction("RegisterStats", "RegisterStats");
                }
                catch (Exception)
                {
                    return View();
                }
            return View(user);
        }
        public class MyUser
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
