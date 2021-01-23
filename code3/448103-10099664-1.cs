    public ActionResult UserStoriesList(int id)
    {
      ActiveEpicId = id;
      var userstories = userRepository.Select().Where(x => x.EpicId.Equals(id)).ToList();
    
      if (Request.IsAjaxRequest())
        return PartialView("_UserStoriesList", userstories);
      else
        return View("UserStoriesList", userstories);
    }
