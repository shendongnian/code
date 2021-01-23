                migration.Alter.Table("foo")
                    .AlterColumn("bar")
                    .AsDateTime()
                    .NotNullable()
                    .SetExistingRowsTo(DateTime.UtcNow)
                ;
