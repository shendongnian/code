    [HttpPost]
    public ActionResult Action(string id)
    {
    // get all data by the student id.
    return Json(listMarks,JsonRequestBehavior.Allow.Get);
    }
