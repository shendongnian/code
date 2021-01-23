    List<String> ServerNames = new List<String>();
    
                    SqlDataSourceEnumerator servers = SqlDataSourceEnumerator.Instance;
                    DataTable serversTable = servers.GetDataSources();
    
                    foreach (DataRow row in serversTable.Rows) {
                        string serverName = row[0].ToString();
    
                        try {
    
                            if (row[1].ToString() != "") {
    
                                serverName += "\\" + row[1].ToString();
    
                            }
    
    
                        }
                        catch {
    
    
                        }
    
                        ServerNames.Add(serverName);
