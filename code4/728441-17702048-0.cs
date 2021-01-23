    public IQueryable GetCompaniesDynamic(string table, string property, string search)
    {
        using (var context = new DBContext())
        {
            return context.Database.SqlQuery("SELECT * FROM dbo." + table + " WHERE "
                                            + property + " = '" + search  + "'");
        }
    }
