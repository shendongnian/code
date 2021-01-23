    public ActionResult GetStoreName(int clientId)
    {
        // of course thath's just an example here. I have strictly no idea
        // what database access technology you are using, how your models look like
        // and so on. Obviously you will have to adapt this query to your data model.
        var client = db.Clients.FirstOrDefault(x => x.Id == clientId);
        if (client == null)
        {
            return HttpNotFound();
        }
    
        return Json(new { storeName = client.Store.Name }, JsonRequestBehavior.AllowGet);
    }
