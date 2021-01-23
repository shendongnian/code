    public ActionResult Upload(UpdateDocumentModel model) {
    ...
      if (imagePath.Length > 247) {
        ViewBag.Message = Errors.Over247;
        return View("UpdateDocument", model);
      }
    ...
    return RedirectToAction("UploadOk");
    }
