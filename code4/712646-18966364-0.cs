            ADOX.Catalog cat = new ADOX.Catalog();
            ADOX.Table table = new ADOX.Table();
            ADOX.Key tableKey = new Key();
            ADOX.Column col = new Column();
            String SecurityDBConnection = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}\\{1};", value, SecurityDBName);
            // Define column with AutoIncrement features
            col.Name = "ID";
            col.Type = ADOX.DataTypeEnum.adInteger;
            // Define security table
            table.Name = "Security";
            table.Columns.Append(col);    // default data type is text[255]
            table.Columns.Append("Username", ADOX.DataTypeEnum.adVarWChar, 255);
            table.Columns.Append("Password", ADOX.DataTypeEnum.adVarWChar, 255);
            table.Columns.Append("Engineer", ADOX.DataTypeEnum.adBoolean);
            table.Columns.Append("Default", ADOX.DataTypeEnum.adBoolean);
            tableKey.Name = "Primary Key";
            tableKey.Columns.Append("ID");
            tableKey.Type = KeyTypeEnum.adKeyPrimary;
            // Add security table to database
            cat.Create(SecurityDBConnection);
            // Must create database file before applying autonumber to column
            col.ParentCatalog = cat;
            col.Properties["AutoIncrement"].Value = true;
            cat.Tables.Append(table);
            // Now, try to connect to cfg file to verify that it was created successfully
            ADODB.Connection con = cat.ActiveConnection as ADODB.Connection;
            if (con != null) con.Close();
