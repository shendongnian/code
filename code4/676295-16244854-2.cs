    /* works */
    session.save(Product);
    session.Save(Warehouse);
    session.Save(Inventory);
    /* works */
    session.Save(Warehouse);
    session.Save(Product);
    session.Save(Inventory);
    /* fails */
    session.Save(Inventory);
    session.Save(Warehouse);
    session.Save(Product);
