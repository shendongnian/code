    connectionInfo.DatabaseName = "";
    connectionInfo.ServerName = <SERVER>;
    connectionInfo.UserID = <USER>;
    connectionInfo.Password =  <PWORD>;
    foreach (Table crTable in crTables)
        {
            crTableLogOnInfo = crTable.LogOnInfo;
            crTableLogOnInfo.ConnectionInfo = connectionInfo;
            crTable.ApplyLogOnInfo(crTableLogOnInfo);
            // if you wish to change the schema name as well, you will need to set   Location property as follows:
             //crTable.Location = "<SCHEMA>." + crTable.Name;
             crTable.Location = "<SCHEMA>." + crTable.LogOnInfo.TableName;
        }
