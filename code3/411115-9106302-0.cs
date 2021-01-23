     connection.Open();
            DataTable schemaTable = connection.GetOleDbSchemaTable(
                OleDbSchemaGuid.Tables,
                new object[] { null, null, null, "TABLE" });
     foreach (DataRow row in schemaTable.Rows )
      {
         Console.WriteLine(row["TABLE_NAME"]);
       }
