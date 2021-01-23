    [Authorize(Roles="Activity Admin")]
    public ActionResult EditActivity(int id)
    {
    	Activity activity = ActivityRepository.GetActivityByID(id);
    	
    	if (activity.CreatorID != CurrentUser.ID)
    	{
    		return RedirectToAction("Activities");
    	}
    	
    	return View(activity);
    }
