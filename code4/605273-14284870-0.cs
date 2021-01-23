       using System;
        using Microsoft.Deployment.WindowsInstaller;
        
        namespace ConsoleApplication1
        {
            class Tester : IDisposable
            {
                Database _database;
        
                public Tester(string databasePath)
                {
                    _database = new Database(databasePath, DatabaseOpenMode.ReadOnly);
                }
        
                public void Dispose()
                {
                    _database.Dispose();
                }
        
                public bool HasTable(string tableName)
                {
                    return _database.Tables.Contains(tableName);
                }
        
                public bool HasColumn(string tableName, string columnName)
                {
                    bool columnExists = false;
                    if (HasTable(tableName))
                    {
                        columnExists = _database.Tables[tableName].Columns.Contains(columnName);
                    }
                    return columnExists;
                }
        
        
                public bool QueryReturnsData(string sqlStatement, params object[] args)
                {
                    return QueryReturnsData(string.Format(sqlStatement, args));
                }
        
                public bool QueryReturnsData(string sqlStatement)
                {
                    bool containsData = false;
                    using (View view = _database.OpenView(sqlStatement))
                    {
                        view.Execute();
                        using (Record rec = view.Fetch())
                        {
                            if(rec != null )
                            {
                                containsData = true;
                            }
                        }
                    }
                    return containsData;
        
                }
        
            }
        }
