      MyDBEntities ctx = new MyDBEntities();
            var objectContext = ((IObjectContextAdapter)ctx).ObjectContext;
            var cols = from meta in objectContext.MetadataWorkspace.GetItems(DataSpace.CSpace)
                       .Where(m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType)
                       from p in (meta as EntityType).Properties
                          .Where(p => p.DeclaringType.Name == "TableName")
                       select new
                       {
                           PropertyName = p.Name                          
                       };
