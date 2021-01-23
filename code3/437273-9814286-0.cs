    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(string id)
    {            
    	ConsoleTBL consoletbl = db.ConsoleTBLs.Find(id);
    	
    	if( consoletbl != null)
    	{
    		db.ConsoleTBLs.Remove(consoletbl);
    		db.SaveChanges();
    	}
    	else
    	{
    		// should probably return an error message
    	}
    	return RedirectToAction("Index");
    }
