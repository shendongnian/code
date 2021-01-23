    public static List<Entity> ReturnList(List<string> VisibleColumns)
            {
                StringBuilder SqlStatement = new StringBuilder();
                SqlStatement.Append("Select ");
                for (int i = 0; i < VisibleColumns.Count; i++)
                {
                    if (i == VisibleColumns.Count - 1)
                    {
                        SqlStatement.Append(VisibleColumns[i]);
                    }
                    else
                    {
                        SqlStatement.Append(VisibleColumns[i]);
                        SqlStatement.Append(",");
                    }
                }
                SqlStatement.Append(" FROM Entity");
                using (var ctx = new DataClasses1DataContext())
                {
                    var result = ctx.ExecuteQuery<Entity>(SqlStatement.ToString());
                    return result.ToList();
                }
    
            }
