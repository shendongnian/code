    public ActionResult Delete(int id)
    {
    	bool success = this.businessLogic.Delete(id); // whatever your business logic is for deleting
    
        object result = success ? "OK" : "ERROR"; // have this be your object that you will return
        return this.Json(result, JsonRequestBehavior.AllowGet);
    }
