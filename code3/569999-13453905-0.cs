      protected override void Seed(AccountServiceEntities context)
            {
                //  This method will be called after migrating to the latest version.
    
                #region SET Defaults for Audit Fields
    
                var types = ReflectionHelper.GetEnumerableOfType<BASE_AUDITED>();
                foreach (var type in types)
                {
                    var method = typeof(ContextExtensions).GetMethod("GetTableName");
                    var generic = method.MakeGenericMethod(type.GetType());
                    var table = generic.Invoke(this, new object[] { context });
    
                    var constraintName = string.Format("DF__{0}__", type.GetType().Name);
    
                    CreateDefaultCronstraint(context, table, constraintName, "Created");
                    CreateDefaultCronstraint(context, table, constraintName, "Modified");
    
                }
    
                #endregion...
