    public static List<Employee> ReturnList(List<string> VisibleColumns)
            {
                StringBuilder SqlStatement = new StringBuilder();
                SqlStatement.Append("Select EmployeeID, ");
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
                SqlStatement.Append(" FROM Employees");
                using (DataClasses1DataContext ctx = new DataClasses1DataContext())
                {
                    var result = ctx.ExecuteQuery<Employee>(SqlStatement.ToString());
                    return result.ToList();
                }
    
            }
