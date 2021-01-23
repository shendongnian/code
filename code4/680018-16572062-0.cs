    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult KendoEmailAdd([DataSourceRequest] DataSourceRequest request, ContactEmail newEmail, int id)
    {
      if (newEmail != null)
      {
        ContactEmail email = new ContactEmail();
        email.DescriptionOf = newEmail.DescriptionOf;
        email.Email = newEmail.Email;
        email.EntityID = id;
        email.PrimaryEmail = newEmail.PrimaryEmail;
        db.ContactEmails.Add(email);
        db.SaveChanges();
      }
      return Json(new[] { newEmail }.ToDataSourceResult(request, ModelState));
    }
