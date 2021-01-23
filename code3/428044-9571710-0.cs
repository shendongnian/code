    using (var tx = Session.BeginTransaction()) {
        category.AddItem(someName);
        category.AddPrice(somePrice);
        session.Save(category);
        tx.Commit();
    }
