    public JsonResult EmailUserKeys(string UserId)
    {
        ...
        return Json(new { success = true }, JsonRequestBehavior.AllowGet);
    }
