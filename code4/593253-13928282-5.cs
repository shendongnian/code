            using (reader = command.ExecuteReader()) {
                /*while (reader.Read()) {
                    ddl_Country.Items.Add(UppercaseFirst(reader[0].ToString()));
                }*/
                ddl_Country.Items.AddRange((
                    from DbDataRecord row in reader
                    select new ListItem(
                        UppercaseFirst(reader.GetString(0))
                    )
                ).ToArray());
            }
