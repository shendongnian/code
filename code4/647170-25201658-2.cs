     public ActionResult UpdateConfirmation(int id)
     {
          XDocument doc = _myDocumentRepository.GetById(id);
          ConfirmationModel model = new ConfirmationModel(doc);
          return View(model);
     }
