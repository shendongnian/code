    public IList<string> GetNames(int p_ID)
    {
        return db.mytable.Where(c => c.ID_fk == p_ID)
                         .Select(x => x.FirstName + " " + x.Surname)
                         .ToList();
    }
