    [HttpPost]
    public ActionResult Save(EmailModel model)
    {
        if (ModelState.IsValid)
        {
            Helper.Save(model);
            return Json(JsonEnvelope.Succes());
        }
        return View(model);
    }
