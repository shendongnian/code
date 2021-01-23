        [HttpPost]
        public ActionResult CreateUser(vw_UserManager_Model_Add_Users newUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var data = new UserManager.Models.UserManagerTestEntities();
                    // Pass model to Data Layer
                    List<string> outcome =  UserManager.DAL.CreateUser(newUser);
                    //data.SaveChanges();
                }
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("showError", ex.Message);
            }
        }
    public ActionResult showError(String sErrorMessage)
    {
        //All we want to do is redirect to the class selection page
        ViewBag.sErrMssg = sErrorMessage;
        return PartialView("ErrorMessageView");
    }
