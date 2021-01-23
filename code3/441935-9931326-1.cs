    public ActionResult Get(int id)
    {
      UserProfileViewModel objVm=new UserProfileViewModel();
      objVM.GravatarURL="http://www.externalsite.com/image/tiyra.jog";
      //Set other properties also.
    
      return View(objVm);
    }
