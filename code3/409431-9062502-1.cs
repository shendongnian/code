    using System;
    using System.Collections.Generic;
    using System.Data;
    using Microsoft.SqlServer.Management.Smo;
    
    
          Server server = new Server(@[yourServer]);
          Database db = server.Databases[yourdatabase];
          List<SqlSmoObject> list = new List<SqlSmoObject>();
          DataTable dataTable = db.EnumObjects(DatabaseObjectTypes.StoredProcedure);
          foreach (DataRow row in dataTable.Rows)
          {
             string sSchema = (string)row["Schema"];
             if (sSchema == "sys" || sSchema == "INFORMATION_SCHEMA")
                continue;
             StoredProcedure sp = (StoredProcedure)server.GetSmoObject(
                new Urn((string)row["Urn"]));
             if (!sp.IsSystemObject)
                list.Add(sp);
          }
          Scripter scripter = new Scripter();
          scripter.Server = server;
          scripter.Options.IncludeHeaders = true;
          scripter.Options.SchemaQualify = true;
          scripter.Options.ToFileOnly = true;
          scripter.Options.FileName = @"C:\fileName.sql";
          scripter.Script(list.ToArray());
     
