    public class NoLockInterceptor : EmptyInterceptor
    {
        public override SqlString OnPrepareStatement(SqlString sql)
            {
                //var log = new StringBuilder();
                //log.Append(sql.ToString());
                //log.AppendLine();
    
                // Modify the sql to add hints
                if (sql.StartsWithCaseInsensitive("select"))
                {
                    var parts = sql.ToString().Split().ToList();
                    var fromItem = parts.FirstOrDefault(p => p.Trim().Equals("from", StringComparison.OrdinalIgnoreCase));
                    int fromIndex = fromItem != null ? parts.IndexOf(fromItem) : -1;
                    var whereItem = parts.FirstOrDefault(p => p.Trim().Equals("where", StringComparison.OrdinalIgnoreCase));
                    int whereIndex = whereItem != null ? parts.IndexOf(whereItem) : parts.Count;
    
                    if (fromIndex == -1)
                        return sql;
    
                    parts.Insert(parts.IndexOf(fromItem) + 3, "WITH (NOLOCK)");
                    for (int i = fromIndex; i < whereIndex; i++)
                    {
                        if (parts[i - 1].Equals(","))
                        {
                            parts.Insert(i + 3, "WITH (NOLOCK)");
                            i += 3;
                        }
                        if (parts[i].Trim().Equals("on", StringComparison.OrdinalIgnoreCase))
                        {
                            parts[i] = "WITH (NOLOCK) on";
                        }
                    }
                    // MUST use SqlString.Parse() method instead of new SqlString()
                    sql = SqlString.Parse(string.Join(" ", parts));
                }
    
                //log.Append(sql);
                return sql;
            }
    }
