    using(dbDataContext db = new dbDataContext())
    {
      db.DOC.InsertOnSubmit(doc);
      sub.Id = doc.Id;
      db.Sub.InsertOnSubmit(sub);
      db.SubmitChanges();
    }
