    var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
    objectContext.ObjectMaterialized += (sender, e) => {
        var context = sender as ObjectContext; 
        var entity = e.Entity as ClassA;
        if (entity != null) {
           entity.AssociatedDPVs = context.CreateObjectSet<DPV>()
                                          .Where(d => d.ClassName == "ClassA" && d.ObjectID == entity.ID)
                                          .ToDictionary(d => d.Name, d => d.Value);
        }
    };
