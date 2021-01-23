    using (var transaction = session.BeginTransaction()) {
      myEntity = new MyEntity();
      myEntity.Product = product;
      myEntity.Company = company;
      myEntity.Date = date;
      myEntity.CurrentUser = currentUser;
      myEntity.IsManual = true;
      myEntity.Save();
      transaction.Commit();
    }
