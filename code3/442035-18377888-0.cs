    public class NoLockHintsInterceptor : EmptyInterceptor
        {
            public override SqlString OnPrepareStatement(SqlString sql)
            {
                // Modify the sql to add hints
                if (sql.StartsWithCaseInsensitive("select"))
                {
                    var parts = new List<object>((object[]) sql.Parts);
                    object fromItem = parts.FirstOrDefault(p => p.ToString().ToLower().Trim().Equals("from"));
                    int fromIndex = fromItem != null ? parts.IndexOf(fromItem) : -1;
                    object whereItem = parts.FirstOrDefault(p => p.ToString().ToLower().Trim().Equals("where"));
                    int whereIndex = whereItem != null ? parts.IndexOf(whereItem) : parts.Count;
    
                    if (fromIndex == -1)
                        return sql;
    
                    parts.Insert(parts.IndexOf(fromItem) + 2, " with(nolock) ");
                    for (int i = fromIndex; i < whereIndex; i++)
                    {
                        if (parts[i - 1].Equals(","))
                        {
                            parts.Insert(i + 2, " with(nolock) ");
                            i += 2;
                        }
                        if (parts[i].ToString().Trim().EndsWith(" on"))
                        {
                            parts[i] = parts[i].ToString().Replace(" on", " with(nolock) on ");
                        }
                    }
                    sql = new SqlString(parts.ToArray());
                }
                return sql;
            }
        }
