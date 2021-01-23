     public static DataTable ReadMsiPropertyTable(string msiFile, string tableName)
            {
                DataTable dataTable = new DataTable(tableName);
                Type installerType = Type.GetTypeFromProgID("WindowsInstaller.Installer");
                Installer installer = (WindowsInstaller.Installer)Activator.CreateInstance(installerType);
                Database database = installer.OpenDatabase(msiFile, MsiOpenDatabaseMode.msiOpenDatabaseModeReadOnly);
    
                string sqlQuery = String.Format("SELECT * FROM {0}", tableName);
                View view = database.OpenView(sqlQuery);
                view.Execute(null);
    
                Record names = view.ColumnInfo[MsiColumnInfo.msiColumnInfoNames];
                Record types = view.ColumnInfo[MsiColumnInfo.msiColumnInfoTypes];
                Record row = view.Fetch();
    
                for (int index = 1; index < names.FieldCount+1; index++)
                {
                    string columnName = names.get_StringData(index);
                    string columnSpec = types.get_StringData(index);
    
                    switch (columnSpec.Substring(0, 1).ToLower())
                    {
                        case "s":
                            dataTable.Columns.Add(columnName, typeof(String));
                            break;
    
                        case "l":
                            dataTable.Columns.Add(columnName, typeof(String));
                            break;
    
                        case "i":
                            dataTable.Columns.Add(columnName, typeof(Int32));
                            break;
    
                        case "v":
                            dataTable.Columns.Add(columnName, typeof (Stream));
                            break;
                    }
                }
    
                while (row != null)
                {
                    DataRow dataRow = dataTable.NewRow();
                    for (int index = 0; index < dataTable.Columns.Count; index++)
                    {
    
                        if(dataTable.Columns[index].DataType == typeof(String))
                        {
                            dataRow[index] = row.StringData[index + 1];
                        }
                        else if(dataTable.Columns[index].DataType == typeof(Int32))
                        {
                            dataRow[index] = row.IntegerData[index + 1];
                        }
                        else if(dataTable.Columns[index].DataType == typeof(Stream))
                        {
                           // Insanity has it's limits. Not implemented.
                        }
                    }
                    dataTable.Rows.Add(dataRow);
                    row = view.Fetch();
                }
                return dataTable;
            }
