    [HttpPost]
    public ActionResult DeleteServices(List<Int32> serMapId)
    {
      int success = -1;
      if (serMapId.Count > 0 )
      {
        int count = RequestDL.DelServices(serMapId);
        if (count > 0)
        {
          success = count;
        }
      }
      return Json(success);
    }
