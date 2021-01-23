    foreach (var entityType in context.MetadataWorkspace
                                      .GetItems<EntityType>(DataSpace.SSpace))
    {
         string tableName = entityType.MetadataProperties
                                      .Single(m => m.Name == "Name")
                                      .Value
                                      .ToString();
         var members = (ReadOnlyMetadataCollection<EdmMember>)entityType
                                                  .MetadataProperties
                                                  .Single(m => m.Name == "Members")
                                                  .Value;
         
         foreach (var columnName in members.Select(m => m.Name))
         {
                        
         }
    }
