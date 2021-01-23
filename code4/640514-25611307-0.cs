    DataTable indexes = conn.GetSchema("Indexes");
    List<string> PrimaryKeys = new List<string>();
    foreach (DataRow row in indexes.Rows)
      if (Convert.ToBoolean(row["PRIMARY_KEY"]))
        PrimaryKeys.Add(row["TABLE_NAME"] + "." + row["COLUMN_NAME"]);
