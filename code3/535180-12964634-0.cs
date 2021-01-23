    public static int? GetMaxLength<T>(Expression<Func<T, string>> column)
        {
            int? result = null;
            using (var context = new EfContext())
            {
                var entType = typeof(T);
                var columnName = ((MemberExpression) column.Body).Member.Name;
                var objectContext = ((IObjectContextAdapter) context).ObjectContext;
                var test = objectContext.MetadataWorkspace.GetItems(DataSpace.CSpace);
                if(test == null)
                    return null;
                var q = test
                    .Where(m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType)
                    .SelectMany(meta => ((EntityType) meta).Properties
                    .Where(p => p.Name == columnName && p.TypeUsage.EdmType.Name == "String"));
                var queryResult = q.Where(p =>
                                              {
                                                  var match = p.DeclaringType.Name == entType.Name;
                                                  if (!match)
                                                      match = entType.Name == p.DeclaringType.Name;
                                                  return match;
                                              })
                    .Select(sel => sel.TypeUsage.Facets["MaxLength"].Value)
                    .ToList();
                if (queryResult.Any())
                    result = Convert.ToInt32(queryResult.First());
                return result;
            }
        }
