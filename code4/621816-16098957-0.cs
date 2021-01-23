        using (var context = new DbContext("<Your connection string right in here>"))
        {
            var constructors = typeof (DbMigrator).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            var hackedDbMigrator = constructors[0].Invoke(new object[] { new Configuration(), context }) as DbMigrator;
            hackedDbMigrator.Update();
        }
