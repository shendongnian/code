            var table = new DataTable("Foo");
            table.Columns.AddRange(new []
            {
                new DataColumn("FooPropertyName", typeof(int))
                {
                    Unique = true,
                    AutoIncrement = true
                },
                new DataColumn("SomeFkPropertyName")
                {
                    Unique = true,
                    AllowDBNull = true
                },
            });
            table.PrimaryKey = new[] {table.Columns[0]};
            table.Rows.Add(0, 0);
            table.Rows.Add(1, 1);
            table.Rows.Add(2, DBNull.Value);
            table.Rows.Add(3, DBNull.Value); // Exception here
