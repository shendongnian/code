    //
    // POST: /Divisions/Delete
    [HttpPost, ActionName("Delete"), Authorize]
    public ActionResult DeleteConfirmed(int id)
    {
    	Division division = _db.Divisions.Single(x => x.DivisionId == id);
    
    	string errorMessage;
    	if (DbRelationEnforcer.CanDelete(_db, division, out errorMessage))
    	{
    		division.SetDeleted(User.Identity.Name);
    		_db.SaveChanges();
    		return Json(new JsonResponseCreatePartial { Success = true }, JsonRequestBehavior.AllowGet);
    	}
    
    	return Json(new JsonResponseCreatePartial { Success = false, Message = errorMessage }, JsonRequestBehavior.AllowGet);
    }
