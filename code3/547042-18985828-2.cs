    private void SoftDelete(DbEntityEntry entry)
    {
        var e = entry.Entity as ModelBase;
        string tableName = GetTableName(e.GetType());
        Database.ExecuteSqlCommand(
                 String.Format("UPDATE {0} SET IsDeleted = 1 WHERE ID = @id", tableName)
                 , new SqlParameter("id", e.ID));
        //Marking it Unchanged prevents the hard delete
        entry.State = EntityState.Unchanged;
    }
