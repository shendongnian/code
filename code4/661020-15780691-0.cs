    public void CreatePackage()
    {
      Package package= new Package();
      ConnectionManager sqlConnection = GetSQLConnection(package,
                                        "localhost", "Database Name");
      TaskHost taskHost=null;
       for(int i=0;i<GetNoOfRowFromSQL();i++)
        {
          CreateDynamicTask(package);
        }
      package.Execute();
    }
    public void CreateDynamicTask(package Package)
    {
       
          //Add the Execute SQL Task
          package.Executables.Add("STOCK:SQLTask");
           taskHost = package.Executables[0] as TaskHost;
          taskHost.Properties["SqlStatementSource"].SetValue(taskHost, 
                                                "EXECUTE Stored Proc);
         //Setting the Isolation Level
         taskHost.Properties["IsolationLevel"].SetValue(taskHost, 1048576);
         //the number signify 1048576 =Serializable
        }
    }
