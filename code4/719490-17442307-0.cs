    for (int i = 0; i < reportDocument.DataSourceConnections.Count; i++)
                    {
                        reportDocument.DataSourceConnections[i].SetConnection(Server.Name, Database.Name, Server.User.Name,Server.User.Password);
                        reportDocument.DataSourceConnections[i].SetLogon(Server.User.Name, Server.User.Password);
                    }
