                        // get the description of the Products table from SyncDB dtabase
                        tableDesc = SqlSyncDescriptionBuilder.GetDescriptionForTable(values, serverConn);
                        // add the table description to the sync scope definition
                        scopeDesc.Tables.Add(tableDesc);
                        // create a server scope provisioning object based on the ProductScope
                        serverProvision = new SqlSyncScopeProvisioning(serverConn, scopeDesc);
                        // skipping the creation of table since table already exists on server
                        serverProvision.SetCreateTableDefault(DbSyncCreationOption.Skip);
                        // start the provisioning process
                        serverProvision.Apply();
                        //Console.WriteLine(values);`
