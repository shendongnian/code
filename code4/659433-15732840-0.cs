      TypeBuilder builder = Program.CreateTypeBuilder(
                    "MyDynamicAssembly", "MyModule", "MyType");
      Program.CreateAutoImplementedProperty(builder, "name", typeof(string));
      Program.CreateAutoImplementedProperty(builder, "type", typeof(string));
      Program.CreateAutoImplementedProperty(builder, "id", typeof(int));
      Type resultType = builder.CreateType();
      dynamic queryResult = context.Database.SqlQuery(
                        resultType, "SELECT * FROM sys.sysobjects");
