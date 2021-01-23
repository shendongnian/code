    [HttpPost]
    public ActionResult Edit(InvoiceDetailsViewModel invoice) {
      using (var context = new HyperContext(WebSecurity.CurrentUserId)) {
        if (ModelState.IsValid) {
          if (invoice.ID == 0) {
            ModelState.Remove("ID");
            ModelState.Remove("Created");
            ModelState.Remove("CreatedBy");
            ModelState.Remove("Modified");
            ModelState.Remove("ModifiedBy");
            var dbItem = Mapper.Map<eu.ecmt.RecruitmentDatabase.Models.Invoice>(invoice);
            context.Invoices.Add(dbItem);
            context.SaveChanges();
            invoice = Mapper.Map<InvoiceDetailsViewModel>(dbItem);
            FillViewBag(context, invoice);
            return PartialView(invoice);
          }
          else {
            context.Entry(Mapper.Map<eu.ecmt.RecruitmentDatabase.Models.Invoice>(invoice)).State = System.Data.EntityState.Modified;
            context.SaveChanges();
            return Content(Boolean.TrueString);
          }
        }
        FillViewBag(context, invoice);
        return PartialView(invoice);
      }
    }
