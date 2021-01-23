    ObjectContext objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
    objectContext.ObjectMaterialized += (sender,e) => {
        var yourEntity = e.Entity as YourEntityType;
        if (yourEntity != null) {
            // Do something
        }
    };
